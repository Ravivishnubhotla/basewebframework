using System;
using System.Collections.Generic;
using System.Text;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;



namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public ISPChannelServiceProxy SPChannelServiceProxyInstance
        {get; set;}
		public ISPChannelParamsServiceProxy SPChannelParamsServiceProxyInstance
        {get; set;}
		public ISPClientServiceProxy SPClientServiceProxyInstance
        {get; set;}
		public ISPMemoServiceProxy SPMemoServiceProxyInstance
        {get; set;}
		public ISPPaymentInfoServiceProxy SPPaymentInfoServiceProxyInstance
        {get; set;}
		public ISPRateServiceProxy SPRateServiceProxyInstance
        {get; set;}
		public ISPRequestInfoServiceProxy SPRequestInfoServiceProxyInstance
        {get; set;}
		public ISPSendClientParamsServiceProxy SPSendClientParamsServiceProxyInstance
        {get; set;}
		public ISPSendRequestInfoServiceProxy SPSendRequestInfoServiceProxyInstance
        {get; set;}




	}
}
