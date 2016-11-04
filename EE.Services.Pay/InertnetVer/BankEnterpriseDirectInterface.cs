using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// [ƽ����������ֱ���ӿ��ĵ�1.0] 
    /// ���ؽ�������ٴη�װ�ɾ���������
    /// </summary>
    public class BankEnterpriseDirectInterface
    {
        #region ���췽��
        private bool IsSpecialLine = false;
        /// <summary>
        ///  �Ƿ�Ϊר�� trueר�� false������ Ĭ�ϻ�����
        /// </summary>
        /// <param name="IsSpecialLine"></param>
        public BankEnterpriseDirectInterface(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }
        #endregion

        #region ˽�з���               
        private DataResult GetResult(ExHashTable parmaKeyDict)
        {
            //��¼��־
            StringBuilder sbLog = new StringBuilder();
            ExHashTable retKeyDict = new ExHashTable();
            try
            {
                //���
                Utils.PayCheckData((string)parmaKeyDict.Get("ThirdLogNo"), (string)parmaKeyDict.Get("CounterId"));
                //��ȡ������
                BankInterface msg = new BankInterface();
                //���ú�����������Ķ���������          
                List<string> messageList = msg.GetBankEnterpriseMessageReq(parmaKeyDict, this.IsSpecialLine);
                var pinganPayConfig = GlobalData.LoadPinganConfig();
                string reqMessage = string.Join("", (pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TeleProtocol == "01" ? messageList.ToArray() : messageList.GetRange(1, 2).ToArray()));
                sbLog.AppendFormat("ʱ��:{0}\r\n", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sbLog.AppendFormat("����:{0}\r\n", reqMessage);
                //����������  //��ȡ���з��ر���
                string recvMessage = msg.SendMessage(reqMessage, pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TeleProtocol);
                sbLog.AppendFormat("��Ӧ:{0}\r\n", recvMessage);
                //�������ؽ��
                retKeyDict = msg.ParsingBankEnterpriseMessageString(recvMessage);
                sbLog.AppendFormat("�������:\r\n{0}\r\n", retKeyDict.ToString());
            }
            catch (Exception ex)
            {
                sbLog.AppendFormat("�쳣��Ϣ:{0}\r\n", ex.Message);
                throw ex;
            }
            finally
            {
                //д����־
                if (GlobalData.LoadPinganConfig().OpenLog)
                    FileHelper.SaveFile(string.Format("Log\\Req\\ReqData_{0}.txt", System.DateTime.Now.ToString("yyyyMMdd")), sbLog.ToString() + "\r\n\r\n");
            }
            //ת��
            return Utils.ToDataResult(retKeyDict, GlobalData.DirectErpBankVersion);
        }
        #endregion

        #region ������ ��ͨ��ѯת�˽ӿ����
        /// <summary>
        /// ϵͳ״̬̽��(S001)
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <returns></returns>
        public DataResult SystemStatusProbeInterface(string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "S001");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        /// <summary>
        /// ��ҵ�˻�����ѯ(4001)  �˽ӿ���Ӧ�������б��ֵĻ����˻�������ѯ�����еĿ������ֻ����������ʽ�״�����������������ڲ����ʽ�ء�������Ҳֻ�������˺ŵ������
        /// �����Ҫ��ѯ�����ֽ�������˻��Ŀ�������Ҫ���á��ֽ�������˻�����ѯ[4059]���ӿڡ�
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="Req_4001">�������</param>     
        /// <param name="counterId">����Ա�� 5λ</param>
        /// <returns></returns>
        public DataResult QueryQiyeAccountBalanceInterface(string serialNumber, Req_4001 req_4001, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            var PinganPayConfig = GlobalData.LoadPinganConfig();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4001");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4001);
            //-------------------
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4001();
            return retKeyDict;
        }

        /// <summary>
        /// 3.3 ��ҵ���ս�����ϸ��ѯ[4002]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4002">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QueryErpTodayTradeDetailInterface(string serialNumber, Req_4002 req_4002, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            var PinganPayConfig = GlobalData.LoadPinganConfig();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4002");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4002);
            //-------------------
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4002();
            return retKeyDict;
        }
        /// <summary>
        /// 3.15 ��ҵ���ս��������ѯ[4008]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4008">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QueryErpTodayTradeDetailedInterface(string serialNumber, Req_4008 req_4008, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4008");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4008);
            //-------------------
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4008();
                var list = new List<Result_4008>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //��ҳ���ѯ����һ����0������ҳ�����1
                        if (model.list.Count > 0)
                        {
                            req_4008.PageNo++;
                            //��־��
                            req_4008.JournalNo = model.JournalNo;
                            //ƫ����
                            req_4008.LogCount = model.LogCount;
                        }
                        //���������ʱ����
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryErpTodayTradeDetailedInterface(serialNumber, req_4008, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                        else
                        {
                            model.list = new List<Result_4008>();
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }

        /// <summary>
        /// ��ҵ�����ʽ�ת(4004)
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4004">�������</param>  
        /// <param name="attachment">�����ļ�</param>
        /// <returns></returns>
        public DataResult QiyeSingleMoneyTransferInterface(string serialNumber, Req_4004 req_4004, string counterId = "", Attachment attachment = null)
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4004");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4004);
            //�����ļ�
            if (attachment != null)
            {
                parmaKeyDict.Add("Attach", attachment);
            }
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4004();
            return retKeyDict;
        }
        /// <summary>
        /// ��ҵ����ʵʱ�ʽ�ת[4014]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4014">�������</param>
        /// <param name="counterId">����Ա��</param>
        /// <returns></returns>
        public DataResult QiyeBatchNoDelayMoneyTransferInterface(string serialNumber, Req_4014 req_4014, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4014");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4014);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4014();
            return retKeyDict;
        }
        /// <summary>
        /// �����ύת��������[400401]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="Req_400401">�������</param>
        /// <param name="counterId">����Ա��</param>
        /// <returns></returns>
        public DataResult SingleSubmitTransferSummaryBatchInterface(string serialNumber, Req_400401 req_400401, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "400401");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_400401);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_400401();
            return retKeyDict;
        }
        /// <summary>
        /// ��ҵ�������ʽ�ת[4018]
        /// </summary>      
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4018">�������</param>
        /// <param name="counterId">����Ա��</param>
        /// <returns></returns>
        public DataResult QiyeLargeBatchMoneyTransferInterface(string serialNumber, Req_4018 req_4018, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������
            parmaKeyDict.Add("TranFunc", "4018");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4018);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4018();
            return retKeyDict;
        }

        /// <summary>
        ///  ��ҵ�����ʽ�ת[4034]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4034">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QiyeSummaryMoneyTransferInterface(string serialNumber, Req_4034 req_4034, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4034");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4034);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4034();
            return retKeyDict;
        }

        /// <summary>
        /// 3.9 ��ҵ�����ʽ�ת[403401]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4034">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QiyeSummaryMoneyTransfer_403401Interface(string serialNumber, Req_4034 req_4034, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "403401");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4034);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4034();
            return retKeyDict;
        }

        /// <summary>
        /// ����ת��ָ���ѯ4005 ���ͱ����������������е�һ�����ѡ��ʹ�ú�������ͬʱ���Ͷ����ѯ�����������ȼ����£�OrigThirdVoucher >  OrigFrontLogNo > OrigThirdLogNo
        /// </summary>       
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4005">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult SingleTransferCmdQueryInterface(string serialNumber, Req_4005 req_4005, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������
            parmaKeyDict.Add("TranFunc", "4005");
            //������ˮ��
            //parmaKeyDict.Add("ThirdLogNo", req_4005.OrigThirdLogNo);
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4005);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4005();
            return retKeyDict;
        }
        /// <summary>
        /// ��ҵ������ϸ��ϸ��Ϣ��ѯ[4006]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4006">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult ErpTradeDetailInfoQueryInterface(string serialNumber, Req_4006 req_4006, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4006");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4006);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4006();
            return retKeyDict;
        }
        /// <summary>
        /// ����ת��ָ���ѯ[4015]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4015">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult LargeBatchTransferCmdQueryInterface(string serialNumber, Req_4015 req_4015, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4015");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4015);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4015();
            return retKeyDict;
        }
        /// <summary>
        /// ��ʷ����ѯ[4012]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="Req_4012">�������</param>     
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult HistoryBalanceQueryInterface(string serialNumber, Req_4012 req_4012, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4012");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4012);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4012();
            return retKeyDict;
        }
        /// <summary>
        /// ��ѯ�˻�������ʷ������ϸ[4013]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4013">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QueryTodayHistoryTransactionDetailInterface(string serialNumber, Req_4013 req_4013, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4013");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4013);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4013();
                var list = new List<Result_4013>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //000001����һҳ���������� A: һ�β�ѯ�����еļ�¼������ҳ�����ǿ�ʼ�ͽ���ʱ�����Ϊͬһ��
                        if (model.list.Count > 0) req_4013.PageNo++;
                        //���������ʱ����
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryTodayHistoryTransactionDetailInterface(serialNumber, req_4013, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// ������֧�����ս��ײ�ѯ[4011]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4011">�������</param>    
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult ProxyBankPayTodayTradeQueryInterface(string serialNumber, Req_4011 req_4011, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4011");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4011);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4011();
            return retKeyDict;
        }
        /// <summary>
        /// �����ϸ��ѯ[4016]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4016">�������</param>    
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult LoanAccountDetailQueryInterface(string serialNumber, Req_4016 req_4016,bool isAll=false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4016");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4016);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4016();
                var list = new List<Result_4016>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //��һ����д1, �ڶ��β�ѯ����д��һ�η���LastSeqNo ��ֵ
                        if (model.list.Count > 0) req_4016.LNNO = model.LastSeqNo;
                        //���������ʱ����
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = LoanAccountDetailQueryInterface(serialNumber, req_4016, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;                
            }
            return retKeyDict;
        }
        /// <summary>
        /// �������кŲ�ѯ[4017]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4017">�������</param>  
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult BankContactNumberQueryInterface(string serialNumber, Req_4017 req_4017, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4017");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4017);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4017();
            return retKeyDict;
        }
        /// <summary>
        /// �밶�˻�ת��[4020]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4020">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult OffshoreAccountTransferInterface(string serialNumber, Req_4020 req_4020, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4020");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4020);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4020();
            return retKeyDict;
        }
        /// <summary>
        /// ֧��ָ����Ʊ��ѯ[4019]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4019">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult PayCmdRefundQueryInterface(string serialNumber, Req_4019 req_4019, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4019");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4019);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4019();
                var list = new List<Result_4019>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.IsEnd != "Y"); i++)
                    {
                        //��1��ʼ����
                        if (model.list.Count > 0) req_4019.PageNo++;
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = PayCmdRefundQueryInterface(serialNumber, req_4019, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// ������������ӿ�[4047]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4047">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult OnBehalfOfWithholdApplayInterface(string serialNumber, Req_4047 req_4047, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4047");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4047);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4047();
            return retKeyDict;
        }
        /// <summary>
        /// �������۽����ѯ�ӿ�[4048]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4048">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult OnBehalfOfWithholdResultQueryInterface(string serialNumber, Req_4048 req_4048, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4048");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4048);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4048();
            return retKeyDict;
        }
        /// <summary>
        /// ��֤ת��[4009]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4009">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult SilverCardTransferMoneyInterface(string serialNumber, Req_4009 req_4009, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4009");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4009);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4009();
            return retKeyDict;
        }
        /// <summary>
        /// ��ѯȯ�̶��ʽ�̨�����[4010]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4010">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QueryBrokerCapitalStationBalanceInterface(string serialNumber, Req_4010 req_4010, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4010");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4010);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4010();
            return retKeyDict;
        }
        /// <summary>
        /// ��������������ӻص���ѯ[401802]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_401802">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult SummaryPatchPaymentReceiptBillInterface(string serialNumber, Req_401802 req_401802, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "401802");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_401802);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_401802();
            return retKeyDict;
        }
        /// <summary>
        /// �������ת�˽ӿ�[4027]      
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4027">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult BlendPatchTransferMoneyInterface(string serialNumber, Req_4027 req_4027, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4027");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4027);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4027();
            return retKeyDict;
        }
        /// <summary>
        /// ��ǿ��ͻ���Ϣ��֤�ӿ�[400101]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_400101">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult DebitCardCustomerInfoVerificationInterface(string serialNumber, Req_400101 req_400101, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "400101");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_400101);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_400101();
            return retKeyDict;
        }
        #endregion

        #region ������ ֱ��������ϸ����
        /// <summary>
        /// 4.1 ��ϸ�����ѯ�ӿ�[F001]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_F001">�������</param>     
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult DetailReportQueryInterface(string serialNumber, Req_F001 req_F001, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "F001");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_F001);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_F001();
            return retKeyDict;
        }
        /// <summary>
        /// 4.2 ��ϸ��������֪ͨ�ӿ�F002 
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_F002">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult DetailReportCreateNotifyInterface(string serialNumber, Req_F002 req_F002, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "F002");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_F002);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }

        #endregion

        #region ������ �ֽ����ӿ����
        /// <summary>
        /// �����˻���Ϣ��ѯ[4021]       
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4021">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult FixedDepositAccountInfoQueryInterface(string serialNumber, Req_4021 req_4021, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4021");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4021);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4021();
                var list = new List<Result_4021>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.PageRecCount.ToInt(0) < model.TotalCount.ToInt(0)); i++)
                    {
                        //��һ�β�ѯ��1�����к������ϴη������һ�����˳���SeqNo+1
                        if (model.list.Count > 0) req_4021.PageNo = model.list[model.list.Count - 1].SeqNo.ToInt(0) + 1;
                        //��ʱ
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = FixedDepositAccountInfoQueryInterface(serialNumber, req_4021, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// ��ѯ����ͨ�浥��Ϣ[4025]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4025">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult QueryLiveComReceiptInfoInterface(string serialNumber, Req_4025 req_4025, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4025");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4025);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4025();
                var list = new List<Result_4025>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.Q10_END_FLG == "N"); i++)
                    {
                        //��һ�β�ѯ��1��������ҳ��ǰһ�η��ص���ʼ�浥���Q10-STR-SEQNO
                        if (model.list.Count > 0) req_4025.ACSEQ = model.Q10_STR_SEQNO;
                        //��ʱ
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryLiveComReceiptInfoInterface(serialNumber, req_4025, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// �������˻�Ԥ��Ϣ/��Ϣ (4054)
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4054">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult WithinGroupAccountPreKnotInterface(string serialNumber, Req_4054 req_4054, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4054");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4054);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4054();
            return retKeyDict;
        }
        /// <summary>
        ///  �ֽ�������ʻ���Լ����/�޸�/ɾ��(4058)
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4058">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(string serialNumber, Req_4058 req_4058, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4058");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4058);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4058();
            return retKeyDict;
        }
        /// <summary>
        /// �������ֹ��鼯�²�[4052]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4052">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult WithinGroupHandModeNotionalPoolDownPickInterface(string serialNumber, Req_4052 req_4052, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4052");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4052);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4052();
            return retKeyDict;
        }
        /// <summary>
        /// �������������˻�������[4057] 
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4057">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult WithinGroupVirtualAccountBalanceAdjustInterface(string serialNumber, Req_4057 req_4057, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4057");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4057);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4057();
            return retKeyDict;
        }

        /// <summary>
        /// 5.4.1 �������˻���ѯ[4022]     
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4022">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult WithinGroupTotalAccountQueryInterface(string serialNumber, Req_4022 req_4022, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4022");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4022);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4022();
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.2 �������˻��б��ѯ [4023]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4023">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult WithinGroupSubAccountListQueryInterface(string serialNumber, Req_4023 req_4023, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4023");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4023);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4023();
                var list = new List<ResultChildAccount_4023>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.PAGE.ToUpper().Trim() == "Y"); i++)
                    {
                        //���˻�ʹ���ϴβ�ѯ�����һ�η��ص����˻�
                        if (model.list.Count > 0) req_4023.SUBAC = model.list[model.list.Count - 1].SUBAC;
                        //��ʱ
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = WithinGroupSubAccountListQueryInterface(serialNumber, req_4023, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.3 �ֽ�����Լ��ѯ[4055] ��ѯ�������˻�����Ͻ���˻����ֽ�����Լ��Ϣ      
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4055">�������</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult CashMangeContractQueryInterface(string serialNumber, Req_4055 req_4055, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4055");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4055);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4055();
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.4 ̨�˼�¼��ѯ[4024] 
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4024">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult LedgerRecordQueryInterface(string serialNumber, Req_4024 req_4024, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4024");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4024);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4024();
                var list = new List<Result_4024>();
                list.AddRange(model.list);
                #region ��ѯ����

                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.turnPageFlag.ToUpper().Trim() == "Y"); i++)
                    {
                        //ʹ���ϴβ�ѯ�����һ�����׼�¼���
                        if (model.list.Count > 0) req_4024.serialNo = model.serialNo;
                        //��ʱ
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = LedgerRecordQueryInterface(serialNumber, req_4024, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }

                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.5 ��Ϣ��ѯ[4056]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4056">�������</param>
        /// <param name="isAll">�Ƿ�һ�β����������� true�� false��</param>
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult JieXiQueryInterface(string serialNumber, Req_4056 req_4056, bool isAll = false, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4056");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4056);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4056();
                var list = new List<Result_4056>();
                list.AddRange(model.list);
                #region ��ѯ��������
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //�������8��
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.list.Count > 0); i++)
                    {
                        //��־��
                        if (model.list.Count > 0) req_4056.HostSeqNo = model.list[model.list.Count - 1].HostSeqNo;
                        //��ʱ
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = JieXiQueryInterface(serialNumber, req_4056, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.6 �ֽ�������˻�����ѯ[4059]
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <param name="req_4059">�������</param>   
        /// <param name="counterId">����Ա</param>
        /// <returns></returns>
        public DataResult CashMangeSubAccountBalanceQueryInterface(string serialNumber, Req_4059 req_4059, string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "4059");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //���ݶ���
            parmaKeyDict.Add("Model", req_4059);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4059();
            return retKeyDict;
        }
        #endregion

        #region ������ Ʊ�ݽӿ����
        /// <summary>
        /// DP00
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <returns></returns>
        public DataResult DP00_Interface(string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "DP00");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);

            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        #endregion

        #region ������ ��Ӧ���ӿ�
        /// <summary>
        /// SC00
        /// </summary>
        /// <param name="serialNumber">������ˮ��</param>
        /// <returns></returns>
        public DataResult SC00_Interface(string counterId = "")
        {
            //���ڴ�����������ĵĲ���
            ExHashTable parmaKeyDict = new ExHashTable();
            //������ˮ��
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //������
            parmaKeyDict.Add("TranFunc", "SC00");
            //������ˮ��
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //����Ա��
            parmaKeyDict.Add("CounterId", counterId);
            //��ȡ���
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        #endregion


    }
}

