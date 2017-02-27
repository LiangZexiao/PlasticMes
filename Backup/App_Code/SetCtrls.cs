using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Text;
using System.Web;

using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Admin.App_Code
{
    public class SetCtrls
    {
        public SetCtrls(){}
        public static DataView GetDataTableFromIList<T>(IList<T> aIList, string sortExpression, string sortDirection)
        {
            DataTable _returnTable = new DataTable();
            if (aIList.Count != 0)
            {
                object _baseObj = aIList[0];
                Type objectType = _baseObj.GetType();
                PropertyInfo[] properties = objectType.GetProperties();

                DataColumn _col;
                foreach (PropertyInfo property in properties)
                {
                    _col = new DataColumn();
                    _col.ColumnName = (string)property.Name;
                    _col.DataType = property.PropertyType;
                    _returnTable.Columns.Add(_col);
                }

                DataRow _row;
                foreach (object objItem in aIList)
                {
                    _row = _returnTable.NewRow();
                    foreach (PropertyInfo property in properties)
                        _row[property.Name] = property.GetValue(objItem, null);
                    _returnTable.Rows.Add(_row);
                }
            }
            DataView _returnDataView = new DataView(_returnTable);
            if (aIList.Count != 0)
            {
                _returnDataView.Sort = sortExpression + " " + sortDirection;
            }

            return _returnDataView;
        }

        public void GetAuthentication(Page dboPage)
        {
            if (dboPage.Session["UserID"] == null)
            {
                dboPage.Response.Write("<script language=javascript>window.top.location='login.aspx';</script>");
            }
                //            
                //dboPage.Response.Redirect("~/login.aspx");
        }

        public void GetSessionInfo(Page dboPage)
        {
            string UserID = dboPage.User.Identity.Name.Trim();
            string PageID = dboPage.ClientID.Trim();
            if (dboPage.User.Identity.IsAuthenticated)
            {
                FormsAuthenticationTicket Tickect = new FormsAuthenticationTicket(1, UserID, DateTime.Now, DateTime.Now.AddMinutes(30), //登陆有效时间
       false, PageID);
                string encryptedTickect = FormsAuthentication.Encrypt(Tickect);
                HttpCookie cookie = FormsAuthentication.GetAuthCookie(UserID, false);
                cookie.Value = encryptedTickect;
                //cookie.Domain = "KernelHacker.com"; //域名，自己定义
                dboPage.Response.AppendCookie(cookie);
                dboPage.Response.Redirect(FormsAuthentication.GetRedirectUrl(UserID, false));
            }
            else
            {
                FormsAuthentication.SetAuthCookie(UserID, false);
            }
        }

        public void GetIdentiryInfo(Page dboPage)
        {
            string UserID = dboPage.User.Identity.Name.Trim();
            string PageID = dboPage.ClientID.Trim();

            if (dboPage.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SetAuthCookie(UserID, false);
            }
            else
            {
                FormsAuthenticationTicket Tickect = new FormsAuthenticationTicket(1, UserID, DateTime.Now, DateTime.Now.AddMinutes(30), //登陆有效时间
false, PageID);
                string encryptedTickect = FormsAuthentication.Encrypt(Tickect);
                HttpCookie cookie = FormsAuthentication.GetAuthCookie(UserID, false);
                cookie.Value = encryptedTickect;
                dboPage.Response.AppendCookie(cookie);
                dboPage.Response.Redirect(FormsAuthentication.GetRedirectUrl(UserID, false));
            }
        }
        public string GetSessionValue(Page dboPage)
        {
            return (dboPage.Session["UserID"] == null) ? null : dboPage.Session["UserID"].ToString().Trim();
        }

        public void SetSessionProgramURL(Page dboPage, string ProgramURL)
        {
            dboPage.Session["ClickMould"] = @ProgramURL + ".aspx";
        }

        public void SetGridView(DropDownList ddl,GridView gv,string fieldname)
        {
            int flag = -1;
            for (int j = 0; j < gv.Rows.Count; j++)
            {
                if (flag == -1)
                {
                    for (int i = 0; i < gv.Columns.Count; i++)
                    {
                        if (gv.Columns[i] as BoundField != null)
                        {
                            if ((gv.Columns[i] as BoundField).DataField.ToUpper().Trim() == fieldname.ToUpper().Trim())
                            {
                                flag = i;
                                break;
                            }
                        }

                        if (gv.Columns[i] as ButtonField != null)
                        {
                            if ((gv.Columns[i] as ButtonField).DataTextField.ToUpper().Trim() == fieldname.ToUpper().Trim())
                            {
                                flag = i;
                                break;
                            }
                        }
                    }
                }
                if (flag == -1) break;
                for (int k = 0; k < ddl.Items.Count; k++)
                {
                    if (gv.Rows[j].Cells[flag].Text.Trim() == ddl.Items[k].Value.Trim())
                        gv.Rows[j].Cells[flag].Text = ddl.Items[k].Text.Trim();
                }
            }
        }

        public bool CheckDateTime(string flag, object start, object end)
        {
            flag = flag.ToUpper();
            if (flag == "OBJECT")
            {
                HtmlInputText HtmlStart = start as HtmlInputText;
                HtmlInputText HtmlEnd = end as HtmlInputText;
                string StartDate = HtmlStart.Value.Trim();
                string EndDate = HtmlEnd.Value.Trim();
                if (StartDate != "" && EndDate != "")
                {
                    return (DateTime.Parse(StartDate) > DateTime.Parse(EndDate)) ? true : false;
                }
                else return false;
            }
            else if (flag == "STRING")
            {
                string StartDate = start.ToString().Trim();
                string EndDate = end.ToString().Trim();
                if (StartDate != "" && EndDate != "")
                {
                    return (DateTime.Parse(StartDate) > DateTime.Parse(EndDate)) ? true : false;
                }
                else return false;
            }
            else return false;
        }

        public void SetExecMsg(Page dboPage, string strMsg)
        {
            dboPage.ClientScript.RegisterClientScriptBlock(
                dboPage.GetType(), "alert", @"<script> window.alert('" + strMsg + @"!!') </script>");
        }

        
        public void SetExecMsg(Page dboPage, string strFlag, bool isFlag)
        {
            strFlag = strFlag.ToUpper();
            string strMsg = string.Empty;
            if (strFlag == "INSERT")
            {
                strMsg = (isFlag) ? "保存成功" : "保存失败";
            }
            else if (strFlag == "UPDATE")
            {
                strMsg = (isFlag) ? "保存成功" : "保存失败";
            }
            else if (strFlag == "DELETE")
            {
                strMsg = (isFlag) ? "删除成功" : "删除失败";
            }
            else if (strFlag == "CHECK")
            {
                strMsg = (isFlag) ? "操作成功" : "操作失败";
            }
            else if (strFlag == "EXISTS")
            {
                if (isFlag) strMsg = "存在相同的资料";
            }
            else if (strFlag == "STARTDATE")
            {
                strMsg = "请输入起始时间";
            }
            dboPage.ClientScript.RegisterClientScriptBlock(
                dboPage.GetType(), "alert", @"<script> window.alert('" + strMsg + @"!!') </script>");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLabel"></param>
        /// <param name="pGridView"></param>
        /// <param name="pDataTable"></param>
        public void SetInfoOfLabel(Label pLabel, GridView pGridView, DataTable pDataTable)
        {
            pLabel.Text = "第 " + (pGridView.PageIndex + 1).ToString() + " 页" + " "
                        + "共 " + pGridView.PageCount.ToString() + " 页" + " "
                        + "总共 " + pDataTable.Rows.Count.ToString() + " 条";
        }

        public void SetPageToLabel(Label PageIndex, Label PageTotal, Label RowsTotal, GridView pGridView, DataTable pDataTable)
        {
            PageIndex.Text = "第 " + (pGridView.PageIndex + 1).ToString() + " 页" + " ";
            PageTotal.Text = "共 " + pGridView.PageCount.ToString() + " 页" + " ";
            RowsTotal.Text = "总共 " + pDataTable.Rows.Count.ToString() + " 条";
        }

        public void SetInfoOfPage(Label pLabel, GridView pGridView, int pPageCount)
        {
            pLabel.Text = "第 " + (pGridView.PageIndex + 1).ToString() + " 页" + " "
                        + "共 " + pGridView.PageCount.ToString() + " 页" + " "
                        + "总共 " + pPageCount.ToString() + " 条";
        }

        public void SetInfoOfPage(Label pDataCount, Label pPageIndex, GridView pGridView, int pPageCount)
        {
            pDataCount.Text = "总共 " + pPageCount.ToString() + " 条";
            pPageIndex.Text = (pGridView.PageIndex + 1).ToString() + "/" + pGridView.PageCount.ToString();
        }

        public void SetInfoOfPageForManyData(Label objDataCount, Label objPageIndex, GridView objGridView, int intDataCount)
        {
            objDataCount.Text = "总共 " + intDataCount.ToString() + " 条";

            int PageSize = objGridView.PageSize;
            int PageCount = (intDataCount % PageSize == 0) ? intDataCount / PageSize : intDataCount / PageSize + 1;

            objPageIndex.Text = objGridView.ToolTip.Trim() + "/" + PageCount.ToString();//(objGridView.PageIndex + 1).ToString() + "/" + PageCount.ToString(); 
        }

        public void SetInfoOfImageButton(ImageButton lkbFirst, ImageButton lkbPrior, ImageButton lkbNext, ImageButton lkbLast, Label objPageIndex, GridView pGridView)
        {
            int PageIndex = int.Parse(pGridView.ToolTip.Trim());
            int PageCount = int.Parse(objPageIndex.Text.Trim().Split('/')[1]);

            lkbFirst.CommandName = "1";
            lkbPrior.CommandName = (PageIndex == 1 ? "1" :(PageIndex - 1).ToString());
            lkbNext.CommandName = (PageCount == 1 ? PageCount.ToString() : (PageIndex + 1).ToString());
            lkbLast.CommandName = PageCount.ToString();
        }

        public void SetInfoOfLinkButtonPage(LinkButton lkbFirst, LinkButton lkbPrev,LinkButton lkbNext, LinkButton lkbLast, GridView pGridView)
        {
            lkbFirst.CommandName = "1";
            lkbPrev.CommandName = (pGridView.PageIndex == 0 ? "1" : pGridView.PageIndex.ToString());
            lkbNext.CommandName = (pGridView.PageCount == 1 ? pGridView.PageCount.ToString() : (pGridView.PageIndex + 2).ToString());
            lkbLast.CommandName = pGridView.PageCount.ToString();
        }

        public void SetInfoOfImageButtonPage(ImageButton lkbFirst, ImageButton lkbPrior, ImageButton lkbNext, ImageButton lkbLast, GridView pGridView)
        {
            lkbFirst.CommandName = "1";
            lkbPrior.CommandName = (pGridView.PageIndex == 0 ? "1" : pGridView.PageIndex.ToString());
            lkbNext.CommandName = (pGridView.PageCount == 1 ? pGridView.PageCount.ToString() : (pGridView.PageIndex + 2).ToString());
            lkbLast.CommandName = pGridView.PageCount.ToString();
        }

        public void SetInfoDropDownList(DropDownList pDropDownList, GridView pGridView)
        {
            pDropDownList.Items.Clear();
            const string FIELDNAME = "ID";
            for (int i = 1; i < pGridView.Columns.Count; i++)
            {
                if (pGridView.Columns[i].Visible && pGridView.Columns[i].HeaderText != "")
                {
                    if ((pGridView.Columns[i] as ButtonField) != null)
                    {
                        if ((pGridView.Columns[i] as ButtonField).DataTextField.ToUpper() != FIELDNAME)
                            pDropDownList.Items.Add(new ListItem(pGridView.Columns[i].HeaderText,
                            ((pGridView.Columns[i] as ButtonField).DataTextField.ToString().Trim())));
                    }
                    else if ((pGridView.Columns[i] as BoundField) != null)
                    {
                        if ((pGridView.Columns[i] as BoundField).DataField.ToUpper() != FIELDNAME)
                            pDropDownList.Items.Add(new ListItem(pGridView.Columns[i].HeaderText,
                            ((pGridView.Columns[i] as BoundField).DataField.ToString().Trim())));
                    }
                    else
                    {

                    }
                }
            }
        }

        public void SetInfoDropDownList(DropDownList pDropDownList, GridView pGridView, string[] FieldNames)
        {
            pDropDownList.Items.Clear();
            //const string FIELDNAME = "ID";
            for (int i = 1; i < pGridView.Columns.Count; i++)
            {
                if (pGridView.Columns[i].Visible)
                {
                    if ((pGridView.Columns[i] as ButtonField) != null)
                    {
                        for (int j = 0; j < FieldNames.Length; j++)
                        {
                            if ((pGridView.Columns[i] as ButtonField).DataTextField.ToUpper() == FieldNames[j].ToUpper())
                                pDropDownList.Items.Add(new ListItem(pGridView.Columns[i].HeaderText,
                                ((pGridView.Columns[i] as ButtonField).DataTextField.ToString().Trim())));
                        }
                    }
                    else if ((pGridView.Columns[i] as BoundField) != null)
                    {
                        for (int j = 0; j < FieldNames.Length; j++)
                        {
                            if ((pGridView.Columns[i] as BoundField).DataField.ToUpper() == FieldNames[j].ToUpper())
                                pDropDownList.Items.Add(new ListItem(pGridView.Columns[i].HeaderText,
                                ((pGridView.Columns[i] as BoundField).DataField.ToString().Trim())));
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        public void SetSelectedValueOfList(Page inputPage, string ControlType, string ControlID, string ListText)
        {
            if (ControlType == "DropDownList")
            {
                DropDownList tempList = inputPage.FindControl(ControlID) as DropDownList;
                foreach (ListItem Items in tempList.Items)
                {
                    if (Items.Text.Equals(ListText))
                    {
                        tempList.SelectedValue = Items.Value;
                        break;
                    }
                }
            }
            else
            {
                RadioButtonList tempList = inputPage.FindControl(ControlID) as RadioButtonList;
                foreach (ListItem Items in tempList.Items)
                {
                    if (Items.Text.Equals(ListText))
                    {
                        tempList.SelectedValue = Items.Value;
                        break;
                    }
                }
            }
        }

        public void SetSelectedValue(DropDownList ddl,string value)
        {
            bool flag = false;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == value)
                {
                    ddl.SelectedValue = value;
                    flag = true;
                    break;
                }
            }
            if (!flag) ddl.SelectedIndex = 0;
        }

        public void SetSelectedTextOfList(Page inputPage, string ControlType, string ControlID, string ListValue)
        {
            if (ControlType == "DropDownList")
            {
                DropDownList tempList = inputPage.FindControl(ControlID) as DropDownList;
                foreach (ListItem Items in tempList.Items)
                {
                    if (Items.Value == ListValue)
                        tempList.SelectedValue = Items.Value;
                }
            }
            else
            {
                RadioButtonList tempList = inputPage.FindControl(ControlID) as RadioButtonList;
                foreach (ListItem Items in tempList.Items)
                {
                    if (Items.Value == ListValue)
                        tempList.SelectedValue = Items.Value;
                }
            }
        }

        public void SetButtonEnabled(bool pFlag, Button btnI, Button btnU, Button btnD)
        {
            btnI.Enabled = pFlag;
            btnU.Enabled = btnD.Enabled = !pFlag;
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, Button btnI, Button btnU, Button btnD, string[] pCtrlType, ArrayList pCtrlID)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;
            for (int i = 0; (i < pCtrlType.Length && pCtrlType.Length == pCtrlID.Count); i++)
            {
                string tempCtrlType = pCtrlType[i];
                if (tempCtrlType.ToUpper() == "TEXTBOX")
                {
                    TextBox[] tb = pCtrlID[i] as TextBox[];
                    for(int j = 0;j<tb.Length;j++)
                        tb[j].Enabled = (pFlag) ? true : false;
                }
                else if (tempCtrlType.ToUpper() == "DROPDOWNLIST")
                {
                    DropDownList[] ddl = pCtrlID[i] as DropDownList[];
                    for (int j = 0; j < ddl.Length; j++)
                        ddl[j].Enabled = (pFlag) ? true : false;
                }
                else if (tempCtrlType.ToUpper() == "HTMLINPUTTEXT")
                {
                    HtmlInputText[] hit = pCtrlID[i] as HtmlInputText[];
                    for(int j = 0;j < hit.Length;j++)
                        hit[j].Disabled = (pFlag) ? false : true;
                }
            }
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, ImageButton btnI, ImageButton btnU, ImageButton btnD, string[] pCtrlType, ArrayList pCtrlID)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;
            for (int i = 0; (i < pCtrlType.Length && pCtrlType.Length == pCtrlID.Count); i++)
            {
                string tempCtrlType = pCtrlType[i];
                if (tempCtrlType.ToUpper() == "TEXTBOX")
                {
                    TextBox[] tb = pCtrlID[i] as TextBox[];
                    for (int j = 0; j < tb.Length; j++)
                        tb[j].Enabled = (pFlag) ? true : false;
                }
                else if (tempCtrlType.ToUpper() == "DROPDOWNLIST")
                {
                    DropDownList[] ddl = pCtrlID[i] as DropDownList[];
                    for (int j = 0; j < ddl.Length; j++)
                        ddl[j].Enabled = (pFlag) ? true : false;
                }
                else if (tempCtrlType.ToUpper() == "HTMLINPUTTEXT")
                {
                    HtmlInputText[] hit = pCtrlID[i] as HtmlInputText[];
                    for (int j = 0; j < hit.Length; j++)
                        hit[j].Disabled = (pFlag) ? false : true;
                }
            }
        }

        public void SetCtrlEnabled(bool pFlag, Button btnI, Button btnU, Button btnD, string pCtrlType, object pCtrlID)
        {
            btnI.Visible = pFlag;
            btnU.Visible = btnD.Enabled = !pFlag;

            if (pCtrlType.ToUpper() == "TEXTBOX")
            {
                TextBox tb = pCtrlID as TextBox;
                tb.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "DROPDOWNLIST")
            {
                DropDownList ddl = pCtrlID as DropDownList;
                ddl.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "HTMLINPUTTEXT")
            {
                HtmlInputText hit = pCtrlID as HtmlInputText;
                hit.Disabled = (pFlag) ? false : true;
            }
        }

        public void SetCtrlEnabled(bool pFlag, ImageButton btnI, ImageButton btnU, ImageButton btnD, string pCtrlType, object pCtrlID)
        {
            btnI.Visible = pFlag;
            btnU.Visible = btnD.Enabled = !pFlag;

            if (pCtrlType.ToUpper() == "TEXTBOX")
            {
                TextBox tb = pCtrlID as TextBox;
                tb.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "DROPDOWNLIST")
            {
                DropDownList ddl = pCtrlID as DropDownList;
                ddl.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "HTMLINPUTTEXT")
            {
                HtmlInputText hit = pCtrlID as HtmlInputText;
                hit.Disabled = (pFlag) ? false : true;
            }
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, Button btnI, Button btnU, Button btnD,string pCtrlType, object pCtrlID)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;

            if (pCtrlType.ToUpper() == "TEXTBOX")
            {
                TextBox tb = pCtrlID as TextBox;
                tb.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "DROPDOWNLIST")
            {
                DropDownList ddl = pCtrlID as DropDownList;
                ddl.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "HTMLINPUTTEXT")
            {
                HtmlInputText hit = pCtrlID as HtmlInputText;
                hit.Disabled = (pFlag) ? false : true;
            }
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, Button btnI, Button btnU, Button btnD)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;

            
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, ImageButton btnI, ImageButton btnU, ImageButton btnD)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;

           
        }

        public void SetCtrlEnabled(bool pFlag, bool pInsert, bool pUpdate, ImageButton btnI, ImageButton btnU, ImageButton btnD, string pCtrlType, object pCtrlID)
        {
            if (pInsert)
            {
                btnI.Visible = pFlag;
                if (pUpdate)
                    btnU.Visible = !pFlag;
            }
            else
                if (pUpdate)
                    btnU.Visible = !pFlag;
            btnD.Enabled = !pFlag;

            if (pCtrlType.ToUpper() == "TEXTBOX")
            {
                TextBox tb = pCtrlID as TextBox;
                tb.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "DROPDOWNLIST")
            {
                DropDownList ddl = pCtrlID as DropDownList;
                ddl.Enabled = (pFlag) ? true : false;
            }
            else if (pCtrlType.ToUpper() == "HTMLINPUTTEXT")
            {
                HtmlInputText hit = pCtrlID as HtmlInputText;
                hit.Disabled = (pFlag) ? false : true;
            }
            else if (pCtrlType.ToUpper() == "HTMLINPUTHIDDEN")
            {
                HtmlInputHidden hid = pCtrlID as HtmlInputHidden;
                hid.Disabled = (pFlag) ? false : true;
            }
            
        }

        public ArrayList GetCancelRecordID(GridView pGridView)
        {
            ArrayList vIDs = new ArrayList();
            foreach (GridViewRow e in pGridView.Rows)
            {
                CheckBox chkItem = e.FindControl("chkItemInner") as CheckBox;
                if (chkItem.Checked)
                {
                    if ((e.Cells[1].Controls[0] as LinkButton) != null)
                        vIDs.Add((e.Cells[1].Controls[0] as LinkButton).Text.Trim());
                    else
                        vIDs.Add(e.Cells[1].Text.ToString().Trim());
                }
            }
            return vIDs;
        }

        /// <summary>
        ///增加函数重载
        /// </summary>
        /// <param name="pGridView">源GridView</param>
        /// <param name="formName">源页表的名字</param>
        /// <returns></returns>
        public ArrayList GetCancelRecordID(GridView pGridView,string formName)
        {
            ArrayList vIDs = new ArrayList();
            ArrayList vStartDate = new ArrayList();

            foreach (GridViewRow e in pGridView.Rows)
            {
                CheckBox chkItem = e.FindControl("chkItemInner") as CheckBox;
                if (chkItem.Checked)
                {
                    if ((e.Cells[1].Controls[0] as LinkButton) != null)
                    {
                        vIDs.Add((e.Cells[1].Controls[0] as LinkButton).Text.Trim());
                    }
                    else
                    {
                        vIDs.Add(e.Cells[1].Text.ToString().Trim());
                    }
                    vStartDate.Add(e.Cells[12].Text.ToString().Trim());
                }
            }
            return gnomesort(vIDs, vStartDate);
        }

        /// <summary>
        ///update by fsq 2010.06.07
        ///优化程序，把原来的双循环改成单循环。
        ///返回一个按照开始日期排序的数组。
        /// </summary>
        /// <param name="vIDs">源数组</param>
        /// <param name="vStartDate">日期数组</param>
        /// <returns></returns>
        public ArrayList gnomesort(ArrayList vIDs, ArrayList vStartDate) 
        { 
            string tmp = string.Empty;
            int i = 0,j;
            if (vIDs == null) return null;
            int n = vIDs.Count;
            while (i < n)  
            {
                if (i == 0 || Convert.ToDateTime(vStartDate[i - 1].ToString())<=Convert.ToDateTime(vStartDate[i].ToString())) i++;
                else
                {
                    j = i;
                    tmp = vStartDate[i].ToString();
                    vStartDate[i] = vStartDate[i - 1];
                    vStartDate[--i] = tmp;

                    tmp = vIDs[j].ToString();
                    vIDs[j] = vIDs[j - 1];
                    vIDs[--j] = tmp;
                }
            }

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i+1; j < n; j++)
            //    {
            //        if (Convert.ToDateTime(vStartDate[i].ToString()) > Convert.ToDateTime(vStartDate[j].ToString()))
            //        {
            //            tmp = vStartDate[i].ToString();
            //            vStartDate[i] = vStartDate[j];
            //            vStartDate[j] = tmp;

            //            tmp = vIDs[i].ToString();
            //            vIDs[i] = vIDs[j];
            //            vIDs[j] = tmp;
            //        }
            //    }
            //}
            return vIDs;
        }

        public DropDownList SetSelectedIndex(DropDownList pDropDownList, string pSelectedValue)
        {
            bool flag = false;
            for (int i = 0; i < pDropDownList.Items.Count; i++)
            {
                if (pSelectedValue.Trim() == pDropDownList.Items[i].Value.Trim())
                {
                    flag = true;
                    pDropDownList.SelectedValue = pSelectedValue;
                }
            }
            if (!flag)
            {
                //string strvalue = pDropDownList.Items[0].Value;
                //string strtext = pDropDownList.Items[0].Text;
                //pDropDownList.Items.Remove();
                //pDropDownList.Items.Add(new ListItem(strtext,strvalue));
                pDropDownList.SelectedIndex = 0;
            }
            return pDropDownList;
        }

        public void SetDropDownList(DropDownList pDropDownList, IList pIList, string pField_Value, string pField_Text)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = pIList;
            pDropDownList.DataTextField = pField_Text.Trim();
            pDropDownList.DataValueField = pField_Value.Trim();
            pDropDownList.DataBind();
            if (pIList.Count == 0) pDropDownList.Items.Insert(0, new ListItem("", ""));
        }
        public void SetDropDownList(DropDownList pDropDownList, DataTable dt, string pField_Value, string pField_Text)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = dt;
            pDropDownList.DataTextField = pField_Text.Trim();
            pDropDownList.DataValueField = pField_Value.Trim();
            pDropDownList.DataBind();
            if (dt.Rows.Count == 0) pDropDownList.Items.Insert(0, new ListItem("", ""));
        }
        public void SetDropDownList(DropDownList pDropDownList, DataTable dt, bool isFlag, string pField_Value, string pField_Text)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = dt;
            pDropDownList.DataTextField = dt.Columns[pField_Text].ToString().Trim();
            pDropDownList.DataValueField = dt.Columns[pField_Value].ToString().Trim();
            pDropDownList.DataBind();
            if (isFlag)
                pDropDownList.Items.Insert(0, new ListItem("全部", ""));
            else
            {
                if (dt.Rows.Count == 0) pDropDownList.Items.Insert(0, new ListItem("", ""));
                else pDropDownList.Items.Insert(0, new ListItem("选择", ""));
            }
        }

        public void SetDropDownList(DropDownList pDropDownList, IList pIList, bool isFlag, string pField_Value, string pField_Text)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = pIList;
            pDropDownList.DataTextField = pField_Text ;
            pDropDownList.DataValueField = pField_Value.Trim();
            pDropDownList.DataBind();
            if (isFlag)
            {
                pDropDownList.Items.Insert(0, new ListItem("全部", ""));
            }
            else
            {
                if (pIList.Count == 0) pDropDownList.Items.Insert(0, new ListItem("", ""));
                else pDropDownList.Items.Insert(0, new ListItem("选择", ""));
            }
        }

        public void SetDropDownList(DropDownList pDropDownList, DataTable dt, bool isFlag, string pField_Value, string pField_Text,string SelectedValue)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = dt;
            pDropDownList.DataTextField = dt.Columns[pField_Text].ToString().Trim();
            pDropDownList.DataValueField = dt.Columns[pField_Value].ToString().Trim();
            pDropDownList.DataBind();

            if (isFlag)
            {
                pDropDownList.Items.Insert(0, new ListItem("全部", ""));
            }

            if (!string.IsNullOrEmpty(SelectedValue))
            {
                for (int i = 0; i < pDropDownList.Items.Count; i++)
                {
                    if (pDropDownList.Items[i].Value == SelectedValue)
                        pDropDownList.SelectedValue = SelectedValue;
                }
            }
        }
        public void SetDropDownList(DropDownList pDropDownList, IList pIList, bool isFlag, string pField_Value, string pField_Text, string SelectedValue)
        {
            pDropDownList.Items.Clear();
            pDropDownList.DataSource = pIList;
            pDropDownList.DataTextField = pField_Text.Trim();
            pDropDownList.DataValueField = pField_Value.Trim();
            pDropDownList.DataBind();

            if (isFlag)
            {
                pDropDownList.Items.Insert(0, new ListItem("全部", ""));
            }

            if (!string.IsNullOrEmpty(SelectedValue))
            {
                for (int i = 0; i < pDropDownList.Items.Count; i++)
                {
                    if (pDropDownList.Items[i].Value == SelectedValue)
                        pDropDownList.SelectedValue = SelectedValue;
                }
            }
        }

        public void InitCtrls(Page dboPage, string[] CtrlType, ArrayList CtrlID)
        {
            for (int i = 0; (i < CtrlType.Length && CtrlType.Length == CtrlID.Count); i++)
            {
                string tempCtrlType = CtrlType[i];
                if (tempCtrlType.ToUpper() == "TEXTBOX")
                {
                    TextBox[] tb = CtrlID[i] as TextBox[];
                    for (int j = 0; j < tb.Length; j++)
                        tb[j].Text = null;
                }
                else if (tempCtrlType.ToUpper() == "DROPDOWNLIST")
                {
                    DropDownList[] ddl = CtrlID[i] as DropDownList[];
                    for (int j = 0; j < ddl.Length; j++)
                        ddl[j].SelectedIndex = 0;
                }
                else if (tempCtrlType.ToUpper() == "HTMLINPUTTEXT")
                {
                    HtmlInputText[] hit = CtrlID[i] as HtmlInputText[];
                    for (int j = 0; j < hit.Length; j++)
                        hit[j].Value = null;
                }
                else
                {
                    Image[] img = CtrlID[i] as Image[];
                    for (int j = 0; j < img.Length; j++)
                        img[j].ImageUrl = null;
                }
            }
        }

        public void InitCtrls(Page dboPage, string CtrlType,object[] CtrlID)
        {
            CtrlType = CtrlType.ToUpper();
            if (CtrlType == "TEXTBOX")
                foreach (TextBox tb in CtrlID)
                    tb.Text = null;
            else if (CtrlType == "DROPDOWNLIST")
                foreach (DropDownList ddl in CtrlID)
                    ddl.SelectedIndex = 0;
            else if (CtrlType == "RADIOBUTTONLIST")
                foreach (RadioButtonList rbl in CtrlID)
                    rbl.SelectedIndex = 0;
            else if (CtrlType == "HTMLINPUTTEXT")
                foreach (HtmlInputText hit in CtrlID)
                    hit.Value = null;
            else if (CtrlType == "IMAGE")
                foreach (Image img in CtrlID)
                    img.ImageUrl = null;
        }

        public void SetGridViewColorOfMouseEvent(GridView pGridView)
        {
            foreach (GridViewRow e in pGridView.Rows)
            {
                if (e.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
                {
                    //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                    e.Attributes.Add("onmouseover",
                        "currentcolor=this.style.backgroundColor;this.style.backgroundColor='yellow',this.style.fontWeight='';");
                    //当鼠标离开的时候 将背景颜色还原的以前的颜色
                    e.Attributes.Add("onmouseout",
                        "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                    //单击行改变行背景颜色
                    e.Attributes.Add("onclick",
                        "this.style.backgroundColor='#99cc00'; this.style.color='buttontext';this.style.cursor='default';");
                }

                //if (e.RowType == DataControlRowType.Header || e.RowType == DataControlRowType.DataRow)
                //{
                //    CheckBox mycb = new CheckBox();
                //    mycb = (CheckBox)e.FindControl("chkItemInner");
                //    if (mycb != null)
                //    {
                //        if (e.RowType == DataControlRowType.DataRow)
                //        {
                //            if (e.RowIndex % 2 == 0)
                //            {
                //                mycb.Attributes.Add("onclick", "changecolor(this.name,'#EFF3FB')");
                //            }
                //            else
                //            {
                //                mycb.Attributes.Add("onclick", "changecolor(this.name,'White')");
                //            }
                //        }
                //        else if (e.RowType == DataControlRowType.Header)
                //        {
                //            mycb.Attributes.Add("onclick", "SelectAll(this.checked)");
                //        }
                //    }
                //}
            }
        }
        /// <summary>
        /// 取得起始和结束的啤数序号
        /// </summary>
        /// <param name="pddlImageIndex"></param>
        /// <returns></returns>
        public string[] GetTotalNumOfDrawPicture(DropDownList pddlImageIndex)
        {
            string[] TotalNum = new string[2] { "0", "0"};
            DropDownList ddlImageIndex = pddlImageIndex;

            int StartNum = int.Parse(ddlImageIndex.SelectedValue.Trim());
            if (StartNum == 0) return TotalNum;
            int ItemsCnt = ddlImageIndex.Items.Count;
            if (ItemsCnt <= 100)
            {
                TotalNum = new string[2] { 
                    ddlImageIndex.Items[0].Text.Trim(),
                    ddlImageIndex.Items[ItemsCnt - 1].Text.Trim(),
                };
            }
            else
            {
                TotalNum = new string[2] { StartNum.ToString(), (StartNum - (100 - 1)).ToString() };
                for (int i = 0; i < TotalNum.Length; i++)
                {
                    for (int j = 0; j < ddlImageIndex.Items.Count; j++)
                    {
                        if (TotalNum[i] == ddlImageIndex.Items[j].Value.Trim())
                        {
                            TotalNum[i] = ddlImageIndex.Items[j].Text.Trim();
                            break;
                        }
                    }
                }
            }
            return TotalNum;
        }
        /// <summary>
        /// 翻页按钮的处理
        /// </summary>
        /// <param name="lkbClick"></param>
        /// <param name="lkbNext"></param>
        /// <param name="lkbPrior"></param>
        /// <param name="ddlImageIndex"></param>
        /// <param name="Mold"></param>
        public void ShowWhichPicture(LinkButton lkbClick, LinkButton lkbNext, LinkButton lkbPrior, DropDownList ddlImageIndex, int Mold)
        {
            if (lkbClick.CommandName == "Next")
            {
                if (ddlImageIndex.SelectedValue.Trim() != "0")
                {
                    if (Int32.Parse(ddlImageIndex.SelectedValue.Trim()) > Mold)
                    {
                        ddlImageIndex.SelectedValue = (Int32.Parse(ddlImageIndex.SelectedValue.Trim()) - Mold).ToString().Trim();
                        lkbPrior.Enabled = true;
                        lkbNext.Enabled = true;
                    }
                    else
                    {
                        ddlImageIndex.SelectedIndex = ddlImageIndex.Items.Count - 1;
                        lkbPrior.Enabled = true;
                        lkbNext.Enabled = false;
                    }
                }
            }
            else
            {
                if (Int32.Parse(ddlImageIndex.SelectedValue.Trim()) > Mold)
                {
                    ddlImageIndex.SelectedValue = (Int32.Parse(ddlImageIndex.SelectedValue.Trim()) + Mold).ToString().Trim();
                }
                else
                {
                    if (ddlImageIndex.SelectedIndex == ddlImageIndex.Items.Count - 1)
                    {
                        ddlImageIndex.SelectedIndex = 0;
                    }
                    else
                        ddlImageIndex.SelectedValue = (Int32.Parse(ddlImageIndex.SelectedValue.Trim()) + Mold).ToString().Trim();
                }

                lkbPrior.Enabled = (ddlImageIndex.SelectedIndex == 0) ? false : true;
                lkbNext.Enabled = (ddlImageIndex.Items.Count <= Mold) ? false : true;
            }
            if (int.Parse(ddlImageIndex.SelectedValue.Trim()) <= Mold)  lkbClick.Enabled = false;
            if (ddlImageIndex.SelectedIndex == ddlImageIndex.Items.Count - 1) lkbClick.Enabled = false;
        }


        /// <summary>
        /// 设置下一页,上一页能否作用
        /// </summary>
        /// <param name="lkbNext"></param>
        /// <param name="lkbPrior"></param>
        /// <param name="ddlImageIndex"></param>
        /// <param name="Mold"></param>
        public void SetLinkButtonOfPageIndex(LinkButton lkbNext, LinkButton lkbPrior, DropDownList ddlImageIndex, int Mold)
        {
            Mold = (Mold == 0) ? 1 : Mold;
            if (int.Parse(ddlImageIndex.SelectedValue.Trim()) <= Mold) lkbNext.Enabled = false;
            lkbPrior.Enabled = (ddlImageIndex.SelectedIndex == 0) ? false : true;
        }


     
    }
}