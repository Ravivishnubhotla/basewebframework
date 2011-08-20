using System;
using System.Collections.Generic;
using System.Text;
using SPS.Bussiness.ServiceProxys.Tables;



namespace SPS.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public ISPChannelServiceProxy SPChannelServiceProxyInstance
        {get; set;}
		public ISPChannelFiltersServiceProxy SPChannelFiltersServiceProxyInstance
        {get; set;}
		public ISPChannelParamsServiceProxy SPChannelParamsServiceProxyInstance
        {get; set;}
		public ISPChannelSycnParamsServiceProxy SPChannelSycnParamsServiceProxyInstance
        {get; set;}
		public ISPClientCodeRelationServiceProxy SPClientCodeRelationServiceProxyInstance
        {get; set;}
		public ISPClientCodeSycnParamsServiceProxy SPClientCodeSycnParamsServiceProxyInstance
        {get; set;}
		public ISPCodeServiceProxy SPCodeServiceProxyInstance
        {get; set;}
		public ISPCodeFilterServiceProxy SPCodeFilterServiceProxyInstance
        {get; set;}
		public ISPDayReportServiceProxy SPDayReportServiceProxyInstance
        {get; set;}
		public ISPMemoServiceProxy SPMemoServiceProxyInstance
        {get; set;}
		public ISPMonitoringRequestServiceProxy SPMonitoringRequestServiceProxyInstance
        {get; set;}
		public ISPPhoneAreaServiceProxy SPPhoneAreaServiceProxyInstance
        {get; set;}
		public ISPRecordServiceProxy SPRecordServiceProxyInstance
        {get; set;}
		public ISPRecordExtendInfoServiceProxy SPRecordExtendInfoServiceProxyInstance
        {get; set;}
		public ISPSClientServiceProxy SPSClientServiceProxyInstance
        {get; set;}
		public ISPUpperServiceProxy SPUpperServiceProxyInstance
        {get; set;}




	}
}
