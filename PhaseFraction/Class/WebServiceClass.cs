using System;
using System;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing;
using System.Diagnostics;

namespace PhaseFraction
{
    class WebServiceClass
    {
        public static Alarmshow MsgofWebSer = null;   //報警(寫在ggevent函數內)
        public static WebServiceClass m_instance;
        public static WebServiceClass instance()
        {
            if (m_instance == null)
                m_instance = new WebServiceClass();
            return m_instance;
        }
        

        public string[] GetMainParam(string lotNo, string tableNo)
        {
            string[] postMsg = new string[9];
            for (int i = 0; i < postMsg.Length; i++)
            {
                postMsg[i] = string.Empty;
            }
            string layer = string.Empty;
            try
            {
                //第四步: 批號獲料號,層別,數量 ,執行第五步 若不需要層別,數量,數據,請忽略第四步,第五步輸入批號,層別
                //第6個參數: 批號
                //para1 = "MF87273521";
                //ds = webServiceSZ.ws.wsGetFun("test", "test", "#01", "0007", "0002", para1, System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0007", "0002", lotNo, dateTime);
                layer = ds.Tables[0].Rows[0]["層別"].ToString();
                if (layer == string.Empty)
                {
                    postMsg[0] = string.Empty;//為空
                    return postMsg;
                }
            }
            catch (Exception ex)
            {
                postMsg[0] = ex.Message;
                return postMsg;
            }


            try
            {
                //第五步: 根據 批號,層別 帶出 料號,在製層,途程序,主途程序,制程,主配件,層別名稱,第幾次過站,工令  ;若查詢結果沒有值,則卡住報錯:獲取途程信息失敗,若有值,則進行第六步(請先在生產日報表制程綁定裏面綁定對應制程)
                //第6個參數: 批號|表單編號|層別
                //para1 = "MF88020361|SFCZ4_ZDCVL |0";
                //ds = webServiceSZ.ws.wsGetFun("test", "test", "#01", "0007", "0009", para1, System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                string pValue = lotNo + "|" + tableNo + "|" + layer;
                string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0007", "0009", pValue, dateTime);
                postMsg[0] = layer;
                postMsg[1] = ds.Tables[0].Rows[0]["工令"].ToString();
                postMsg[2] = ds.Tables[0].Rows[0]["途程序"].ToString();
                postMsg[3] = ds.Tables[0].Rows[0]["在製層"].ToString();
                postMsg[4] = ds.Tables[0].Rows[0]["層別名稱"].ToString();
                postMsg[5] = ds.Tables[0].Rows[0]["第幾次過站"].ToString();
                postMsg[6] = ds.Tables[0].Rows[0]["主途程序"].ToString();
                postMsg[7] = ds.Tables[0].Rows[0]["料號"].ToString();
                postMsg[8] = ds.Tables[0].Rows[0]["數量"].ToString();
            }
            catch (Exception ex)
            {
                postMsg[1] = ex.Message;
                return postMsg;
            }
            return postMsg;

        }


        public bool GetWorkLicence(string deviceNo, string id)
        {
            string pValue = deviceNo + "|" + id;
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", deviceNo, "0010", "HR001", pValue, dateTime);
                string result = ds.Tables[0].Rows[0][0].ToString();
                if (result != "OK")
                {
                    MsgofWebSer("該工號未獲取上崗證！" + id + result, LogType.FlowLog, true);
                    return true;
                }
                else
                {
                    MsgofWebSer("該工號獲取上崗證成功！" + id, LogType.FlowLog, false);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("獲取上崗證失敗！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }
        
        public string GetBOMParamFH02(string lotNo)
        {
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                //M106050292
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0024", "FH02", lotNo, dateTime);
                string result = ds.Tables[0].Rows[0][0].ToString();
                if (result != string.Empty)
                {
                    MsgofWebSer("获取BOM信息成功！批號：" + lotNo + "，結果：" + result, LogType.FlowLog, false);
                    return result;
                }
                else
                {
                    MsgofWebSer("获取BOM信息失敗！批號：" + lotNo + "，結果：" + result, LogType.FlowLog, true);
                    return result;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("获取BOM信息失敗！批號：" + lotNo + "，結果：" + ex.Message, LogType.FlowLog, true);
                return string.Empty;
            }
        }

        public string GetBOMParam(string partNo, string layer, string mainSerial)
        {
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string pValue = partNo + "|" + layer;
            string result = string.Empty;
            try
            {
                DataSet ds = webServiceDll.ws.getDataFromSer("test", "test", "#01", "0005", "0011", pValue, dateTime);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string procNo = ds.Tables[0].Rows[i]["PROC_NO"].ToString();
                    string serial = ds.Tables[0].Rows[i]["SERIAL"].ToString();
                    if (procNo == "451" && serial == mainSerial)
                    {
                        result = ds.Tables[0].Rows[i]["V_WSADDVALUE"].ToString();
                        break;
                    }
                }
                if (result != string.Empty)
                {
                    MsgofWebSer("获取BOM信息成功！參數：" + pValue + "，" + mainSerial + "，結果：" + result, LogType.FlowLog, false);
                    return result;
                }
                else
                {
                    MsgofWebSer("获取BOM信息失敗！參數：" + pValue + "，" + mainSerial + "，結果：" + result, LogType.FlowLog, true);
                    return result;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("获取BOM信息失敗！參數" + pValue + "，" + mainSerial + "，結果：" + ex.Message, LogType.FlowLog, true);
                return result;
            }
        }

        public bool GetBoardParam(string boardCode, out string[] outParam)
        {
            outParam = new string[8];
            for (int i = 0; i < outParam.Length; i++)
            {
                outParam[i] = string.Empty;
            }
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "0051", boardCode, dateTime);
                //outParam[0] = ds.Tables[0].Rows[0]["ITEM3"].ToString();
                outParam[0] = ds.Tables[0].Rows[0]["ITEM2"].ToString();
                outParam[1] = ds.Tables[0].Rows[0]["ITEM6"].ToString();
                outParam[2] = ds.Tables[0].Rows[0]["ITEM5"].ToString();
                outParam[3] = ds.Tables[0].Rows[0]["ITEM17"].ToString();
                outParam[4] = ds.Tables[0].Rows[0]["ITEM19"].ToString();
                outParam[5] = ds.Tables[0].Rows[0]["ITEM20"].ToString();
                outParam[6] = ds.Tables[0].Rows[0]["ITEM21"].ToString();
                if (outParam[1] != string.Empty && outParam[4] != string.Empty && outParam[6] != string.Empty)
                {
                    MsgofWebSer("获取網板信息成功！編號：" + boardCode + "，結果：" + outParam[1] + outParam[4] + outParam[6], LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer("获取網板信息失敗！編號：" + boardCode + "，結果：" + outParam[1] + outParam[4] + outParam[6], LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("获取網板信息失敗！編號：" + boardCode + "，結果：" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }

        public bool GetKnifeParam(string knifeCode, out string[] outParam)
        {
            outParam = new string[3];
            for (int i = 0; i < outParam.Length; i++)
            {
                outParam[i] = string.Empty;
            }
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "0050", knifeCode, dateTime);
                outParam[0] = ds.Tables[0].Rows[0]["ITEM1"].ToString();
                outParam[1] = ds.Tables[0].Rows[0]["ITEM2"].ToString();
                outParam[2] = ds.Tables[0].Rows[0]["ITEM6"].ToString();
                if (outParam[0] != string.Empty && outParam[1] != string.Empty && outParam[2] != string.Empty)
                {
                    MsgofWebSer("获取刮刀信息成功！編號：" + knifeCode + "，結果：" + outParam[0] + outParam[1] + outParam[2], LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer("刮刀沒有生產記錄！編號：" + knifeCode + "，結果：" + outParam[0] + outParam[1] + outParam[2], LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("获取刮刀信息失敗！編號：" + knifeCode + "，結果：" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }

        public bool GetOilParam(string oilCode, out string[] outParam)
        {
            outParam = new string[6];
            for (int i = 0; i < outParam.Length; i++)
            {
                outParam[i] = string.Empty;
            }
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "0052", oilCode, dateTime);
                string result=ds.Tables[0].Rows[0]["LASTVALUE"].ToString();
                outParam = result.Split(',');

                if (outParam[0] != string.Empty && outParam[1] != string.Empty && outParam[2] != string.Empty && outParam[3] != string.Empty && outParam[4] != string.Empty)
                {
                    MsgofWebSer("获取油墨信息成功！編號：" + oilCode + "，結果：" + result, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer("获取油墨信息失敗！編號：" + oilCode + "，結果：" + result, LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("获取油墨信息失敗！編號：" + oilCode + "，結果：" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }


        public bool CreateTableNo(string deviceNo, string tableNo)
        {
            //第三步: 插入主表數據 ,  執行第四步
            //第7個參數: 表單號|狀態|日期(系統日期-8小時)|機台號|表單編號|班別(0 白班 1 夜班)|廠區(QHDA02,QHDA06,QHDA07)|創建時間|創建工號
            //ret = webServiceSZ.ws.wsSendFun(
            //    "test", "test", "#01", "0005", "0003",
            //    "PaperNo|Status|Dodate|MachineNo|Report|ClassInfo|Factory|CreateTime|CreateEmpid",
            //    "test2018030200343|1|20180302|TEST|SFCZ4_ZDCVL|0|QHDA06|" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "|G1479462",
            //    System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            string[] values = new string[9];
            values[0] = tableNo;//表單號
            values[1] = "1";//狀態,默認為1
            values[2] = DateTime.Now.AddHours(-8).ToString("yyyyMMdd");//日期
            values[3] = deviceNo;//機臺號
            values[4] = "SFCZ4_ZD_FHYS_Dtl";//默認表單編號  

            string str1 = "8:00";
            string str2 = "20:30";
            DateTime dt1 = Convert.ToDateTime(str1);
            DateTime dt2 = Convert.ToDateTime(str2);
            DateTime dt3 = DateTime.Now;
            if ((DateTime.Compare(dt3, dt1) > 0) && (DateTime.Compare(dt3, dt2) < 0))
            {
                values[5] = "0";//白班
            }
            else
            {
                values[5] = "1";//夜班
            }
            values[6] = "QHDA06";//廠區別
            values[7] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//創建時間
            values[8] = Variable.CreateEmpid; 
            string dataTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string result = string.Empty;
            string pName = "PaperNo|Status|Dodate|MachineNo|Report|ClassInfo|Factory|CreateTime|CreateEmpid";
            string pValue = string.Empty;
            for (int i = 0; i < values.Length - 1; i++)
            {
                pValue += values[i] + "|";
            }
            pValue += values[values.Length - 1];
            try
            {
                result = webServiceDll.ws.wsSendFun("test", "test", "#01", "0005", "0003", pName, pValue, dataTime);
                if (result == "OK")
                {
                    MsgofWebSer("主表單上传成功！pName:" + pName + ",pValue:" + pValue, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer("主表單上传失败！pName:" + pName + ",pValue:" + pValue, LogType.FlowLog, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("主表單上传失败！" + ex.Message + ",pName:" + pName + ",pValue:" + pValue, LogType.FlowLog, false);
                return false;
            }
        }



        public bool InsertToReport(string PaperNo, string MacState, string StartTime, string EndTime, string Lotnum,
                                   string Layer, string MainSerial, string Partnum, string WorkNo, string SfcLayer,
                                   string LayerName, string Serial, string IsMain, string OrderId, string Item1,
                                   string Item2, string Item3, string Item4, string Item35, string Item36, string Item37,
                                   string Item5, string Item6, string Qty, string Item34, string Item15, string Item16,
                                   string Item39, string Item40, string Item41, string Item42, string Item43, string Item44,
                                   string Item17, string Item45, string Item46, string Item47, string Item48, string Item7,
                                   string Item8, string Item10, string Item11, string Item12, string Item13, string Item14,
                                   string USERID, string Isfirst, string FirstCheck, string FirstCheckStatus,
                                   string FirstCheckEmpid, string FirstCheckTime, string QCCheck, string qcchecktime,
                                   string CreateEmpid, string CreateTime, string ModifyEmpid, string ModifyTime)
        {
            //第六步: 明細表數據插入
            //para1 = "PaperNo|StartTime|lLot|Lotnum|Layer|sfclayer|LayerName|mainserial|serial|workno|Item1|Item2|Item3|Item4|Item5|Item6|Item7|Item8|Item9|" +
            //    "Item10|Qty|Item11|Item12|Item13|Item14|Item15|Item16|Item17|Item18";
            //para2 = "2018082400921|20181110014309|FSNW003A1A|M808172031|60|60|主要+CVL-ACVL-B|17|8|WN6-I80309|5|FSNW003A1ASTA|0|0|90|90|7|SG10046|FSNW003STAA1A|" +
            //    "G1478673|12|5|G1478673|STA|0.225mm|16188052-A602222|STA|0.225mm|16188052-A602222";
            //ret = webServiceSZ.ws.wsSendFun("test", "test", "#01", "0005", "0006", para1, para2, System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));


            string pName = "PaperNo|MacState|StartTime|EndTime|Lotnum|Layer|MainSerial|Partnum|WorkNo|SfcLayer|LayerName|" +
                           "Serial|IsMain|OrderId|Item1|Item2|Item3|Item4|Item35|Item36|Item37|Item5|Item6|Qty|Item34|Item15|" +
                           "Item16|Item39|Item40|Item41|Item42|Item43|Item44|Item17|Item45|Item46|Item47|Item48|Item7|Item8|" +
                           "Item10|Item11|Item12|Item13|Item14|USERID|Isfirst|FirstCheck|FirstCheckStatus|FirstCheckEmpid|" +
                           "FirstCheckTime|QCCheck|qcchecktime|CreateEmpid|CreateTime|ModifyEmpid|ModifyTime";

            string pValue = PaperNo + "|" + MacState + "|" + StartTime + "|" + EndTime + "|" + Lotnum + "|" + Layer + "|" + 
                            MainSerial + "|" + Partnum + "|" + WorkNo + "|" + SfcLayer + "|" + LayerName + "|" +
                            Serial + "|" + IsMain + "|" + OrderId + "|" + Item1 + "|" + Item2 + "|" + Item3 + "|" + Item4 + "|" + Item35 + "|" +
                            Item36 + "|" + Item37 + "|" + Item5 + "|" + Item6 + "|" + Qty + "|" + Item34 + "|" + Item15 + "|" +
                            Item16 + "|" + Item39 + "|" + Item40 + "|" + Item41 + "|" + Item42 + "|" + Item43 + "|" + Item44 + "|" + 
                            Item17 + "|" + Item45 + "|" + Item46 + "|" + Item47 + "|" + Item48 + "|" + Item7 + "|" + Item8 + "|" +
                            Item10 + "|" + Item11 + "|" + Item12 + "|" + Item13 + "|" + Item14 + "|" + USERID + "|" + Isfirst + "|" + 
                            FirstCheck + "|" + FirstCheckStatus + "|" + FirstCheckEmpid + "|" +
                            FirstCheckTime + "|" + QCCheck + "|" + qcchecktime + "|" + CreateEmpid + "|" + 
                            CreateTime + "|" + ModifyEmpid + "|" + ModifyTime;
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string result = string.Empty;
            try
            {
                result = webServiceDll.ws.wsSendFun("test", "test", "#01", "0005", "0006", pName, pValue, dateTime);
                if (result == "OK")
                {
                    MsgofWebSer("明細表上传成功！pname:" + pName + ",pvalue:" + pValue, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer("明細表上传失败！pname:" + pName + ",pvalue:" + pValue, LogType.FlowLog, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer("明細表上传失败！" + ex.Message + ",pname:" + pName + ",pvalue:" + pValue, LogType.FlowLog, false);
                return false;
            }
        }


        public bool GetTableNo(string deviceNo, out string tableNo)
        {
            //第一步: 已有表單單號查詢 ,獲取當天,當班,同一機台 單號,若有,則抓取該單號,執行第四步(跳過第二,第三步),若沒有 ,則執行第二步.
            //第六個參數:表單編號|日期(系統日期-8小時)|機台號|班別(0:白班 ,1:夜班)
            //ds = webServiceSZ.ws.wsGetFun("test", "test", "#01", "0005", "G0001", "SFCZ4_ZDCVL|20181121|PNLAVI002#(E)|0", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            string dateTime = DateTime.Now.AddHours(-8).ToString("yyyyMMdd");//年月日
            string str1 = "8:00";
            string str2 = "20:30";

            DateTime dt1 = Convert.ToDateTime(str1);
            DateTime dt2 = Convert.ToDateTime(str2);
            DateTime dt3 = DateTime.Now;
            string classInfo = string.Empty;//班別
            if ((DateTime.Compare(dt3, dt1) > 0) && (DateTime.Compare(dt3, dt2) < 0))
            {
                classInfo = "0";//白班
            }
            else
            {
                classInfo = "1";//夜班
            }
            try
            {
                string pValue = "SFCZ4_ZD_FHYS_Dtl" + "|" + dateTime + "|" + deviceNo + "|" + classInfo;
                string dateTimeNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "G0001", pValue, dateTimeNow);
                tableNo = ds.Tables[0].Rows[0]["單號"].ToString();//讀取表單號
                MsgofWebSer("表單第一次查询成功！pValue:" + pValue + "單號:" + tableNo, LogType.FlowLog, false);
                return true;
            }
            catch
            {
                try
                {
                    Thread.Sleep(1000);
                    string pValue = "SFCZ4_ZD_FHYS_Dtl" + "|" + dateTime + "|" + deviceNo + "|" + classInfo;
                    string dateTimeNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "G0001", pValue, dateTimeNow);
                    tableNo = ds.Tables[0].Rows[0]["單號"].ToString();//讀取表單號
                    MsgofWebSer("表單第二次查询成功！pValue:" + pValue + "單號:" + tableNo, LogType.FlowLog, false);
                    return true;
                }
                catch
                {
                    //第二步:調用 系統生產單號 方法 ,獲取單號,之後執行第三步
                    //第六個參數: 日期(系統日期-8小時)|班別(0:白班 ,1:夜班)
                    //ds = webServiceSZ.ws.wsGetFun("test", "test", "#01", "0005", "G0002", "20180926|0", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    try
                    {
                        string pValue = dateTime + "|" + classInfo;
                        string dateTimeNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        DataSet ds = webServiceDll.ws.wsGetFun("test", "test", "#01", "0005", "0002", pValue, dateTimeNow);
                        tableNo = ds.Tables[0].Rows[0]["單號"].ToString();//讀取表單號
                        MsgofWebSer("表單查询失败，创建新表单成功！pValue:" + pValue + "單號:" + tableNo, LogType.FlowLog, false);
                        CreateTableNo(deviceNo, tableNo);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tableNo = string.Empty;
                        MsgofWebSer("表單查询失败，创建新表单失败！" + ex.Message, LogType.FlowLog, true);
                        return false;
                    }
                }
            }
        }
        public bool WebServiceTest()
        {
            try
            {
                string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                webServiceDll.ws.wsFun("test", "test", "#01", "test", "test", dateTime);
                MsgofWebSer("网络正常!", LogType.ListShow, false);
                return true;
            }
            catch
            {
                MsgofWebSer("网络异常!", LogType.ListShow, true);
                return false;
            }
        }

        public bool UpLoadMachineState(string deviceNo, string errorState, string waitingState, string producingState)
        {
            string pName = "Error|Waiting|Producing";
            string pValue = errorState + "|" + waitingState + "|" + producingState;
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                string result = webServiceDll.ws.wsSendFun("F7035659", "7035659", deviceNo, "0008", "0000", pName, pValue, dateTime);
                if (result == "OK")
                {
                    MsgofWebSer(deviceNo + "稼動率上傳成功！" + result + pName + pValue, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer(deviceNo + "稼動率上傳失敗！" + result + pName + pValue, LogType.FlowLog, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer(deviceNo + "稼動率上傳失敗！" + ex.Message + pName + pValue, LogType.FlowLog, false);
                return false;
            }
        }

        // 地址：http://10.86.12.13:8001/WebServiceForQHD/Service1.asmx
        //（測試地址）
        //調用方法：webServiceDll.ws.getDataFromSer
        //碁鼎防焊WIP架（方法名：getDataFromSer）
        //username(用戶):YAHEHOU
        //password(密碼):SAOMAJILU
        //equid(設備編號):PNLCELLFCTH0003#
        //groupid(分組ID):0028
        //funid(方法ID):MWS_YH01
        //PARA1(參數值):MAC地址|條碼,設備IP,設備編號
        //PARA2(參數值)： 10E7C643D62E|000M108111,10.86.169.188,DLAR02D00330
        //createDate(獲取時間):DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        // PARA1(參數值)="10E7C643D62E|000M108111,10.86.169.188,DLAR02D00330"；
        //ds = webServiceDll.ws.getDataFromSer("廠商英文名稱", "設備名稱", "設備編號", "0028", "MWS_YH01", para1, uploadTime);
        //返回值
        //OK       ret = ds.Tables[0].Rows[0][0].ToString();

        public bool UpLoadBarcode(string barcode, string deviceNo, string emsNo, string ip, string mainSerial, string lotNo, string operatorID = "")
        {
            Regex regOK = new Regex("^OK.*");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();
            string uploadStr = emsNo + "|" + barcode + "," + ip + "," + deviceNo + "," + mainSerial + "," + lotNo;
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                DataSet ds = webServiceDll.ws.getDataFromSer("YAHEHOU", "SAOMAJILU", deviceNo, "0028", "MWS_YH01", uploadStr, dateTime);
                string result = ds.Tables[0].Rows[0][0].ToString();
                string timeElapsed = Convert.ToString(stopWatch.ElapsedMilliseconds);
                if (regOK.IsMatch(result))
                {
                    MsgofWebSer(result + ",數據：" + uploadStr + ",耗時：" + timeElapsed, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer(result + ",數據：" + uploadStr + ",耗時：" + timeElapsed, LogType.FlowLog, false);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string timeElapsed = Convert.ToString(stopWatch.ElapsedMilliseconds);
                MsgofWebSer(ex.Message + ",數據：" + uploadStr + ",耗時：" + timeElapsed, LogType.FlowLog, false);
                return false;
            }
        }
      
        public bool UpLoadBarcodeTest(string barcode, string deviceNo, string mac, string ip)
        {
            Regex regOK = new Regex("^OK.*");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();
            string uploadStr = barcode + "|" + deviceNo + "," + ip;
            string dateTime=DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                WebReference.MWS_S1 web = new WebReference.MWS_S1();
                string ret = web.MWS_IO_POOL_INSERT(mac, uploadStr, dateTime);
                string timeElapsed = Convert.ToString(stopWatch.ElapsedMilliseconds);
                if (regOK.IsMatch(ret))
                {
                    MsgofWebSer("二維碼上傳成功：" + uploadStr + "," + mac +  ",耗時：" + timeElapsed, LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    MsgofWebSer(ret + "二維碼上傳失敗：" + uploadStr + "," + mac + ",耗時：" + timeElapsed, LogType.FlowLog, false);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string timeElapsed = Convert.ToString(stopWatch.ElapsedMilliseconds);
                MsgofWebSer(ex.Message + "二維碼上傳失敗：" + uploadStr + "," + mac + ",耗時：" + timeElapsed, LogType.FlowLog, false);
                return false;
            }
        }

        public bool UpLoadBarcode(string barcode, string deviceNo, string mac, string ip)
        {
            Stopwatch stopWatch = new Stopwatch();
            string ret = string.Empty, uploadStr = string.Empty;
            Regex regNG = new Regex("混料");
            Regex regOK = new Regex("OK");
            uploadStr = barcode + "|" + deviceNo + "," + ip;
            WebReference.MWS_S1 web = new WebReference.MWS_S1();
            stopWatch.Reset();
            stopWatch.Start();
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                ret = web.MWS_IO_POOL_INSERT(mac, uploadStr, dateTime);
                if (regOK.IsMatch(ret) && !regNG.IsMatch(ret))
                {
                    MsgofWebSer("二維碼上傳成功：" + uploadStr + "，MAC:" + mac + "，結果：" + ret + "，耗時：" + 
                                Convert.ToString(stopWatch.ElapsedMilliseconds), LogType.FlowLog, false);
                    return true;
                }
                else if (regOK.IsMatch(ret) && regNG.IsMatch(ret))
                {
                    MsgofWebSer("二維碼上傳混料：" + uploadStr + "，MAC:" + mac + "，結果：" + ret + "，耗時：" + 
                               Convert.ToString(stopWatch.ElapsedMilliseconds), LogType.FlowLog, true);
                    return false;
                }
                else
                {
                    MsgofWebSer("二維碼上傳成功：" + uploadStr + "，MAC:" + mac + "，結果：" + ret + "，耗時：" + 
                                Convert.ToString(stopWatch.ElapsedMilliseconds), LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofWebSer(ex.Message + "，二維碼上傳失敗：" + uploadStr + "，MAC:" + mac + "，結果：" + ret +
                            "，耗時：" + Convert.ToString(stopWatch.ElapsedMilliseconds), LogType.FlowLog, true);
                return false;
            }

        }

       
    }
}
