using System;
using System.Collections.Generic;
using System.Text;

namespace LD.SPPipeManage.Data.Tables.Container
{
    public partial class DataObjectContainers
    {
        public DataObjectContainers()
        {
        }

      public SPDayReportDataObject SPDayReportDataObjectInstance { set; get; }
      public SPTestRecievedDataObject SPTestRecievedDataObjectInstance { set; get; }
      public SPChannelDataObject SPChannelDataObjectInstance { set; get; }
      public SPChannelParamsDataObject SPChannelParamsDataObjectInstance { set; get; }
      public SPClientDataObject SPClientDataObjectInstance { set; get; }
      public SPClientChannelSettingDataObject SPClientChannelSettingDataObjectInstance { set; get; }
      public SPMemoDataObject SPMemoDataObjectInstance { set; get; }
      public SPPaymentInfoDataObject SPPaymentInfoDataObjectInstance { set; get; }
      public SPRequestInfoDataObject SPRequestInfoDataObjectInstance { set; get; }
      public SPSendClientParamsDataObject SPSendClientParamsDataObjectInstance { set; get; }
      public SPSendRequestInfoDataObject SPSendRequestInfoDataObjectInstance { set; get; }


	}
}
