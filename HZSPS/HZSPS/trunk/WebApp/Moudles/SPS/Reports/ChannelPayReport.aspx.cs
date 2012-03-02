using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ChannelPayReport : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                var structure = new Dictionary<string, string>
                                    {
                                        {"总数", ""},
                                        {"同步下家数", ""},
                                        {"扣量", ""}
                                    };

                var products = new string[] { "下行数 ", "成功数", "成功率" };
                var grid = GridPanel1;
                var view = grid.View[0];
                var store = grid.Store[0];
                var cm = grid.ColumnModel;
                var continentGroupRow = new HeaderGroupRow();
                var data = new object[5];
                var i = 0;
                var random = new Random();

                foreach (KeyValuePair<string, string> keyValuePair in structure)
                {
                    var continent = keyValuePair.Key;

                    continentGroupRow.Columns.Add(new HeaderGroupColumn
                                                      {
                                                          Header = continent,
                                                          Align = Alignment.Center,
                                                          ColSpan = products.Length
                                                      });


                    foreach (string product in products)
                    {
                        store.Reader[0].Fields.Add(continent + product, RecordFieldType.Int);

                        cm.Columns.Add(new Column
                                           {
                                               DataIndex = continent + product,
                                               Header = product,
                                               Renderer =
                                                   {
                                                       Format = RendererFormat.UsMoney
                                                   }
                                           });
                    }

                    var arr = new int[28];

                    for (int j = 0; j < arr.Length; j++)
                    {
                        arr[j] = Convert.ToInt32((Math.Floor(random.NextDouble()*11) + 1)*100000);
                    }

                    data[i++] = arr;
                }

                view.HeaderGroupRows.Add(continentGroupRow);

                store.DataSource = data;
                store.DataBind();
            }
        }
    }
}