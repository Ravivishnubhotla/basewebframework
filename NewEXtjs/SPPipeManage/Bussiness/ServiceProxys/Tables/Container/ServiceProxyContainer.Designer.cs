using System;
using System.Collections.Generic;
using System.Text;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;



namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public ISPDayReportServiceProxy SPDayReportServiceProxyInstance
        {get; set;}
		public ISPTestRecievedServiceProxy SPTestRecievedServiceProxyInstance
        {get; set;}
		public ISPChannelServiceProxy SPChannelServiceProxyInstance
        {get; set;}
		public ISPChannelParamsServiceProxy SPChannelParamsServiceProxyInstance
        {get; set;}
		public ISPClientServiceProxy SPClientServiceProxyInstance
        {get; set;}
		public ISPClientChannelSettingServiceProxy SPClientChannelSettingServiceProxyInstance
        {get; set;}
		public ISPMemoServiceProxy SPMemoServiceProxyInstance
        {get; set;}
		public ISPPaymentInfoServiceProxy SPPaymentInfoServiceProxyInstance
        {get; set;}
		public ISPRequestInfoServiceProxy SPRequestInfoServiceProxyInstance
        {get; set;}
		public ISPSendClientParamsServiceProxy SPSendClientParamsServiceProxyInstance
        {get; set;}
		public ISPSendRequestInfoServiceProxy SPSendRequestInfoServiceProxyInstance
        {get; set;}




	}
}
