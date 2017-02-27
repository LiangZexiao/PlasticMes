using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.DBUtility;
using Admin.Model;

namespace Admin.SQLServerDAL.Product_DAL
{
    public class PackageList_DAL
    {
        TableMstr tm = new TableMstr();
        SQLPreparer objPreparer = new SQLPreparer();


        FormatSqlParas fsp = new FormatSqlParas();
        Common cmm = new Common();
        FormatSqlCmd fsc = new FormatSqlCmd();

        private const string TABLENAME = "PackageList";

        string TableName = "PackageList";
        string[] FieldName1 = { "ID" };
        string[] FieldName2 = { "CompanyName", "PN", "ProdNO", "ProdName", "NumOfBox", "FileNO", 
            "PackageNO", "PackageModel", "GlueBoxNo", "GlueBoxModel", "GluePackageModel", 
            "GluePackageNum", "LongKnifeModel","LongKnifeNum","ShortKnifeModel" ,"ShortKnifeNum", "BlockOffCardModel", "BlockOffCardNum", "FlatCardModel", 
            "FlatCardNum", "AbsorbPlasticModel", "AbsorbPlasticNum", "Notice", "PagkagePhoto", "PagkagePhotoType", "PackageType", "CellLineNum",
            "LineNum","CellPCS", "BoxNum", "TotalPCS", "CellBlockOff", "FlatCard", "NewVer", "ChangedVer", "CONVERT(CHAR(10),EffectDate,121) EffectDate", 
            "NewOldChangedFlag", "NewOldVer", "OldType", "OldType_BoxNum", "OldType_Num", "OldType_CellNum", "OldType_BoxPCS", "OldType_GlueModel", "OldType_Other", 
            "TableMaker", "Checker",  "CONVERT(CHAR(10),EffectedDate,121) EffectedDate", "QCChecker", "VerNO", "TableNO" };
        string[] FieldName3 = { "CompanyName", "PN", "ProdNO", "ProdName", "NumOfBox", "FileNO", 
            "PackageNO", "PackageModel", "GlueBoxNO", "GlueBoxModel", "GluePackageModel", 
            "GluePackageNum", "LongKnifeModel","LongKnifeNum","ShortKnifeModel" ,"ShortKnifeNum", "BlockOffCardModel", "BlockOffCardNum", "FlatCardModel", 
            "FlatCardNum", "AbsorbPlasticModel", "AbsorbPlasticNum", "Notice", "PagkagePhoto", "PagkagePhotoType", "PackageType", "CellLineNum",
            "LineNum","CellPCS", "BoxNum", "TotalPCS", "CellBlockOff", "FlatCard", "NewVer", "ChangedVer", "EffectDate", 
            "NewOldChangedFlag", "NewOldVer", "OldType", "OldType_BoxNum", "OldType_Num", "OldType_CellNum", "OldType_BoxPCS", "OldType_GlueModel", "OldType_Other", 
            "TableMaker", "Checker", "EffectedDate",  "QCChecker", "VerNO", "TableNO" };

        //string fID = "ID";
        //// /////////////////    1
        //string fCompanyName = "CompanyName";
        //string fPN = "PN";
        //string fProdNO = "ProdNO";
        //string fProdName = "ProdName";
        //string fNumOfBox = "NumOfBox";
        //string fFileNO = "FileNO";

        ////                       2
        //string fPackageNO = "PackageNO";
        //string fPackageModel = "PackageModel";
        //string fGlueBoxNO = "GlueBoxNo";
        //string fGlueBoxModel = "GlueBoxModel";
        //string fGluePackageModel = "GluePackageModel";
        ////                       3
        //string fGluePackageNum = "GluePackageNum";
        //string fLongKnifeModel = "LongKnifeModel";
        //string fLongKnifeNum = "LongKnifeNum";
        //string fShortKnifeModel = "ShortKnifeModel";
        //string fShortKnifeNum = "ShortKnifeNum";
        //string fBlockOffCardModel = "BlockOffCardModel";
        //string fBlockOffCardNum = "BlockOffCardNum";
        //string fFlatCardModel = "FlatCardModel";

        ////                4
        //string fFlatCardNum = "FlatCardNum";
        //string fAbsorbPlasticModel = "AbsorbPlasticModel";
        //string fAbsorbPlasticNum = "AbsorbPlasticNum";
        //string fNotice = "Notice";
        //string fPagkagePhoto = "PagkagePhoto";
        //string fPagkagePhotoType = "PagkagePhotoType";
        //string fPackageType = "PackageType";

        //string fCellLineNum = "CellLineNum";
        ////                          5
        //string fLineNum = "LineNum";
        //string fCellPCS = "CellPCS";
        //string fBoxNum = "BoxNum";
        //string fTotalPCS = "TotalPCS";
        //string fCellBlockOff = "CellBlockOff";
        //string fFlatCard = "FlatCard";
        //string fNewVer = "NewVer";
        //string fChangedVer = "ChangedVer";
        //string fEffectDate = "EffectDate";


        //string cfEffectDate = "CONVERT(CHAR(10),EffectDate,121) EffectDate";
        //string fNewOldChangedFlag = "NewOldChangedFlag";
        //string fNewOldVer = "NewOldVer";
        //string fOldType = "OldType";
        //string fOldType_BoxNum = "OldType_BoxNum";
        //string fOldType_Num = "OldType_Num";

        //string fOldType_CellNum = "OldType_CellNum";

        //string fOldType_BoxPCS = "OldType_BoxPCS";
        //string fOldType_GlueModel = "OldType_GlueModel";
        //string fOldType_Other = "OldType_Other";
        //string fTableMaker = "TableMaker";
        //string fChecker = "Checker";
        //string fEffectedDate = "EffectedDate";
        //string cfEffectedDate = "CONVERT(CHAR(10),EffectedDate,121) EffectedDate";
        //string fQCChecker = "QCChecker";
        //string fVerNO = "VerNO";
        //string fTableNO = "TableNO";

        // public DataTable selectPackageList(PackageList_MDL dboPackageList)
        public IList<PackageList_MDL> selectPackageList(int id, string colname, string coltext)
        {

            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfItemMstr(sqlWhere, sqlParas);
        }
        public DataTable selectPackageList(int id, string colname, string coltext, int t)
        {

            StringBuilder sqlWhere = new StringBuilder();
            SqlParameter[] sqlParas = null;

            if (id != 0)
            {
                sqlWhere.Append(string.Format("AND ID=@ID"));
                sqlParas = new SqlParameter[1] { fsp.FormatInParam("@ID", SqlDbType.Int, id) };
            }
            if (colname != "" && coltext != "")
            {
                sqlWhere.Append(string.Format("AND {0} LIKE '%" + coltext + "%'", colname));
            }
            return getDataListOfItemMstr(sqlWhere, sqlParas, t);
        }

        //public DataTable selectPackageList(PackageList_MDL dboPackageList)
        //{


        //    string[] ColumnsName = {fID,
        //        fCompanyName,fPN,fProdNO,fProdName,fNumOfBox,
        //        fFileNO,fPackageNO,fPackageModel,fGlueBoxNO,fGlueBoxModel,

        //        fGluePackageModel,fGluePackageNum,fLongKnifeModel,fLongKnifeNum,fShortKnifeModel,
        //        fShortKnifeNum,fBlockOffCardModel,fBlockOffCardNum,fFlatCardModel, fFlatCardNum,

        //        fAbsorbPlasticModel,fAbsorbPlasticNum,fNotice,
        //        fPagkagePhoto,fPagkagePhotoType,
        //        fPackageType,fCellLineNum,fLineNum,fCellPCS,fBoxNum,fTotalPCS,

        //        fCellBlockOff,fFlatCard,fNewVer,fChangedVer,cfEffectDate,
        //        fNewOldChangedFlag,fNewOldVer,fOldType, fOldType_BoxNum,fOldType_Num,

        //        fOldType_CellNum,fOldType_BoxPCS,fOldType_GlueModel,fOldType_Other,fTableMaker,
        //        fChecker,fEffectedDate,fQCChecker,fVerNO,fTableNO
        //    };
        //    tm.TableName = TABLENAME;
        //    tm.ColumnsName = ColumnsName;
        //    tm.LikeColumnsName = dboPackageList.LikeFieldName;
        //    tm.LikeColumnsText = dboPackageList.LikeFieldText;

        //    tm.KeyColumnsName = new string[1] { fProdNO };
        //    tm.KeyColumnsText = new string[1] { dboPackageList.ProdNO };

        //    return objPreparer.ExecQueryCmd(tm);
        //}

        //public DataTable getPackageListSglRow(PackageList_MDL dboPackageList)
        //{
        //    string[] ColumnsName = {fID,
        //        fCompanyName,fPN,fProdNO,fProdName,fNumOfBox,
        //        fFileNO,fPackageNO,fPackageModel,fGlueBoxNO,fGlueBoxModel,

        //        fGluePackageModel,fGluePackageNum,fLongKnifeModel,fLongKnifeNum,fShortKnifeModel,
        //        fShortKnifeNum,fBlockOffCardModel,fBlockOffCardNum,fFlatCardModel,fFlatCardNum,

        //        fAbsorbPlasticModel,fAbsorbPlasticNum,fNotice,
        //        fPagkagePhoto,fPagkagePhotoType,
        //        fPackageType,fCellLineNum,fLineNum,fCellPCS,fBoxNum,fTotalPCS,

        //        fCellBlockOff,fFlatCard,fNewVer,fChangedVer,cfEffectDate,
        //        fNewOldChangedFlag, fNewOldVer, fOldType,fOldType_BoxNum,fOldType_Num,

        //        fOldType_CellNum,fOldType_BoxPCS,fOldType_GlueModel,fOldType_Other,fTableMaker,
        //        fChecker,cfEffectedDate,fQCChecker,fVerNO,fTableNO
        //    };
        //    tm.TableName = TABLENAME;
        //    tm.ColumnsName = ColumnsName;
        //    tm.KeyColumnsName = new string[1] { fID };
        //    tm.KeyColumnsText = new string[1] { dboPackageList.ID };

        //    return objPreparer.ExecQueryCmd(tm);
        //}

        //public PackageList_MDL choosePackageList(PackageList_MDL dboPackageList)
        //{
        //    string[] ColumnsName = {fID,
        //        fCompanyName,fPN,fProdNO,fProdName,fNumOfBox,
        //        fFileNO,fPackageNO,fPackageModel,fGlueBoxNO,fGlueBoxModel,

        //        fGluePackageModel,fGluePackageNum,fLongKnifeModel,fLongKnifeNum,fShortKnifeModel,
        //        fShortKnifeNum,fBlockOffCardModel,fBlockOffCardNum,fFlatCardModel,fFlatCardNum,

        //        fAbsorbPlasticModel,fAbsorbPlasticNum,fNotice,
        //        fPagkagePhoto,fPagkagePhotoType,
        //        fPackageType,fCellLineNum,fLineNum,fCellPCS,fBoxNum,fTotalPCS,

        //        fCellBlockOff,fFlatCard,fNewVer,fChangedVer,cfEffectDate,
        //        fNewOldChangedFlag, fNewOldVer, fOldType,fOldType_BoxNum,fOldType_Num,

        //        fOldType_CellNum,fOldType_BoxPCS,fOldType_GlueModel,fOldType_Other,fTableMaker,
        //        fChecker,cfEffectedDate,fQCChecker,fVerNO,fTableNO
        //    };
        //    tm.TableName = TABLENAME;
        //    tm.ColumnsName = ColumnsName;
        //    tm.KeyColumnsName = new string[1] { fID };
        //    tm.KeyColumnsText = new string[1] { dboPackageList.V_ID };

        //    DataTable dt = objPreparer.ExecQueryCmd(tm);
        //    PackageList_MDL tempObject = new PackageList_MDL(
        //        dt.Rows[0][fCompanyName].ToString().Trim(),
        //        dt.Rows[0][fPN].ToString().Trim(),
        //        dt.Rows[0][fProdNO].ToString().Trim(),
        //        dt.Rows[0][fProdName].ToString().Trim(),
        //        dt.Rows[0][fNumOfBox].ToString().Trim(),
        //        dt.Rows[0][fFileNO].ToString().Trim(),
        //        dt.Rows[0][fPackageNO].ToString().Trim(),
        //        dt.Rows[0][fPackageModel].ToString().Trim(),
        //        dt.Rows[0][fGlueBoxNO].ToString().Trim(),
        //        dt.Rows[0][fGlueBoxModel].ToString().Trim(),

        //        dt.Rows[0][fGluePackageModel].ToString().Trim(),
        //        dt.Rows[0][fGluePackageNum].ToString().Trim(),
        //        dt.Rows[0][fLongKnifeModel].ToString().Trim(),
        //        dt.Rows[0][fLongKnifeNum].ToString().Trim(),
        //        dt.Rows[0][fShortKnifeModel].ToString().Trim(),
        //        dt.Rows[0][fShortKnifeNum].ToString().Trim(),
        //        dt.Rows[0][fBlockOffCardModel].ToString().Trim(),
        //        dt.Rows[0][fBlockOffCardNum].ToString().Trim(),
        //        dt.Rows[0][fFlatCardModel].ToString().Trim(),
        //        dt.Rows[0][fFlatCardNum].ToString().Trim(),

        //        dt.Rows[0][fAbsorbPlasticModel].ToString().Trim(),
        //        dt.Rows[0][fAbsorbPlasticNum].ToString().Trim(),
        //        dt.Rows[0][fNotice].ToString().Trim(),
        //        null,
        //        null,
        //        dt.Rows[0][fPackageType].ToString().Trim(),
        //        dt.Rows[0][fCellLineNum].ToString().Trim(),
        //        dt.Rows[0][fLineNum].ToString().Trim(),
        //        dt.Rows[0][fCellPCS].ToString().Trim(),
        //        dt.Rows[0][fBoxNum].ToString().Trim(),
        //        dt.Rows[0][fTotalPCS].ToString().Trim(),

        //        dt.Rows[0][fCellBlockOff].ToString().Trim(),
        //        dt.Rows[0][fFlatCard].ToString().Trim(),
        //        dt.Rows[0][fNewVer].ToString().Trim(),
        //        dt.Rows[0][fChangedVer].ToString().Trim(),
        //        dt.Rows[0][fEffectDate].ToString().Trim(),
        //        dt.Rows[0][fNewOldChangedFlag].ToString().Trim(),
        //        dt.Rows[0][fNewOldVer].ToString().Trim(),
        //        dt.Rows[0][fOldType].ToString().Trim(),
        //        dt.Rows[0][fOldType_BoxNum].ToString().Trim(),
        //        dt.Rows[0][fOldType_Num].ToString().Trim(),

        //        dt.Rows[0][fOldType_CellNum].ToString().Trim(),
        //        dt.Rows[0][fOldType_BoxPCS].ToString().Trim(),
        //        dt.Rows[0][fOldType_GlueModel].ToString().Trim(),
        //        dt.Rows[0][fOldType_Other].ToString().Trim(),
        //        dt.Rows[0][fTableMaker].ToString().Trim(),
        //        dt.Rows[0][fChecker].ToString().Trim(),
        //        dt.Rows[0][fEffectedDate].ToString().Trim(),
        //        dt.Rows[0][fQCChecker].ToString().Trim(),
        //        dt.Rows[0][fVerNO].ToString().Trim(),
        //        dt.Rows[0][fTableNO].ToString().Trim()
        //        );
        //    return tempObject;
        //}

        public int ChangePackageList(PackageList_MDL dboPackageList, string UI)
        {
            SqlParameter[] sqlParas ={
                fsp.FormatInParam("@CompanyName", SqlDbType.VarChar, dboPackageList.CompanyName),
                fsp.FormatInParam("@PN", SqlDbType.VarChar, dboPackageList.PN),
                fsp.FormatInParam("@ProdNO", SqlDbType.VarChar, dboPackageList.ProdNO),
                fsp.FormatInParam("@ProdName", SqlDbType.VarChar, dboPackageList.ProdName),
                fsp.FormatInParam("@NumOfBox", SqlDbType.Decimal, dboPackageList.NumOfBox),
                fsp.FormatInParam("@FileNO", SqlDbType.VarChar, dboPackageList.FileNO),
                fsp.FormatInParam("@PackageNO", SqlDbType.VarChar, dboPackageList.PackageNO),
                fsp.FormatInParam("@PackageModel", SqlDbType.VarChar, dboPackageList.PackageModel),
                fsp.FormatInParam("@GlueBoxNO", SqlDbType.VarChar, dboPackageList.GlueBoxNO),
                fsp.FormatInParam("@GlueBoxModel", SqlDbType.VarChar, dboPackageList.GlueBoxModel),

                fsp.FormatInParam("@GluePackageModel", SqlDbType.VarChar, dboPackageList.GluePackageModel),
                fsp.FormatInParam("@GluePackageNum", SqlDbType.Decimal, dboPackageList.GluePackageNum),
                fsp.FormatInParam("@LongKnifeModel", SqlDbType.VarChar, dboPackageList.LongKnifeModel),
                fsp.FormatInParam("@LongKnifeNum", SqlDbType.Decimal, dboPackageList.LongKnifeNum),
                fsp.FormatInParam("@ShortKnifeModel", SqlDbType.VarChar, dboPackageList.ShortKnifeModel),
                fsp.FormatInParam("@ShortKnifeNum", SqlDbType.Decimal, dboPackageList.ShortKnifeNum),
                fsp.FormatInParam("@BlockOffCardModel", SqlDbType.VarChar, dboPackageList.BlockOffCardModel),
                fsp.FormatInParam("@BlockOffCardNum", SqlDbType.Decimal, dboPackageList.BlockOffCardNum),
                fsp.FormatInParam("@FlatCardModel", SqlDbType.VarChar, dboPackageList.FlatCardModel),
                fsp.FormatInParam("@FlatCardNum", SqlDbType.Decimal, dboPackageList.FlatCardNum),

                fsp.FormatInParam("@AbsorbPlasticModel", SqlDbType.VarChar, dboPackageList.AbsorbPlasticModel),
                fsp.FormatInParam("@AbsorbPlasticNum", SqlDbType.Decimal, dboPackageList.AbsorbPlasticNum),
                fsp.FormatInParam("@Notice", SqlDbType.VarChar, dboPackageList.Notice),
                fsp.FormatInParam("@PagkagePhoto", SqlDbType.Image, dboPackageList.PagkagePhoto),
                fsp.FormatInParam("@PagkagePhotoType", SqlDbType.VarChar, dboPackageList.PagkagePhotoType),

                fsp.FormatInParam("@PackageType", SqlDbType.VarChar, dboPackageList.PackageType),
                fsp.FormatInParam("@CellLineNum", SqlDbType.Decimal, dboPackageList.CellLineNum),
                fsp.FormatInParam("@LineNum", SqlDbType.Decimal, dboPackageList.LineNum),
                fsp.FormatInParam("@CellPCS", SqlDbType.VarChar, dboPackageList.CellPCS),
                fsp.FormatInParam("@BoxNum", SqlDbType.Decimal, dboPackageList.BoxNum),
                fsp.FormatInParam("@TotalPCS", SqlDbType.VarChar, dboPackageList.TotalPCS),

                fsp.FormatInParam("@CellBlockOff", SqlDbType.VarChar, dboPackageList.CellBlockOff),
                fsp.FormatInParam("@FlatCard", SqlDbType.VarChar, dboPackageList.FlatCard),
                fsp.FormatInParam("@NewVer", SqlDbType.VarChar, dboPackageList.NewVer),
                fsp.FormatInParam("@ChangedVer", SqlDbType.VarChar, dboPackageList.ChangedVer),
                fsp.FormatInParam("@EffectDate", SqlDbType.DateTime, dboPackageList.EffectDate),
                fsp.FormatInParam("@NewOldChangedFlag", SqlDbType.VarChar, dboPackageList.NewOldChangedFlag),
                fsp.FormatInParam("@NewOldVer", SqlDbType.VarChar, dboPackageList.NewOldVer),
                fsp.FormatInParam("@OldType", SqlDbType.VarChar, dboPackageList.OldType),
                fsp.FormatInParam("@OldType_BoxNum", SqlDbType.Decimal, dboPackageList.OldType_BoxNum),
                fsp.FormatInParam("@OldType_Num", SqlDbType.Decimal, dboPackageList.OldType_Num),

                fsp.FormatInParam("@OldType_CellNum", SqlDbType.Decimal, dboPackageList.OldType_CellNum),
                fsp.FormatInParam("@OldType_BoxPCS", SqlDbType.VarChar, dboPackageList.OldType_BoxPCS),
                fsp.FormatInParam("@OldType_GlueModel", SqlDbType.VarChar, dboPackageList.OldType_GlueModel),
                fsp.FormatInParam("@OldType_Other", SqlDbType.VarChar, dboPackageList.OldType_Other),
                fsp.FormatInParam("@TableMaker", SqlDbType.VarChar, dboPackageList.TableMaker),
                fsp.FormatInParam("@Checker", SqlDbType.VarChar, dboPackageList.Checker),
                fsp.FormatInParam("@EffectedDate", SqlDbType.DateTime, dboPackageList.EffectedDate),
                fsp.FormatInParam("@QCChecker", SqlDbType.VarChar, dboPackageList.QCChecker),
                fsp.FormatInParam("@VerNO", SqlDbType.VarChar, dboPackageList.VerNO),
                fsp.FormatInParam("@TableNO", SqlDbType.VarChar, dboPackageList.TableNO),
                fsp.FormatInParam("@ID",SqlDbType.Int,dboPackageList.ID)
            };
            try
            {
                if (UI == "INSERT")
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetInsertCmd(TableName, FieldName3), sqlParas);
                else
                    return SqlHelper.ExecuteNonQuery(CommandType.Text, fsc.GetUpdateCmd(TableName, FieldName3), sqlParas);
            }
            catch(Exception ex)
            {
                dboPackageList = null;
                return -1;
            }
            finally
            {
                dboPackageList = null;
            }
            //tm.TableName = TABLENAME;
            //tm.ColumnsName = ColumnsName;
            //tm.ColumnsText = ColumnsName;
            //return objPreparer.ExecInsertCmd(tm, parms);
        }

        //public int deletePackageList(PackageList_MDL dboPackageList)
        //{
        //    tm.TableName = TABLENAME;
        //    tm.KeyColumnsName = new string[1] { fID };
        //    tm.KeyColumnsText = new string[1] { dboPackageList.V_ID };
        //    return objPreparer.ExecDeleteCmd(tm);
        //}
        public int cancelItemMstr(ArrayList _IDList)
        {
            string ExecBatch = "BEGIN TRANSACTION ";
            foreach (string s in _IDList)
                ExecBatch += string.Format("DELETE PackageList WHERE ID={0} IF(@@ROWCOUNT=0 OR @@ERROR<>0) GOTO StopDot ", s);
            ExecBatch += " COMMIT TRANSACTION RETURN StopDot: ROLLBACK TRANSACTION RETURN ";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, ExecBatch, null);
        }

        //public int cancelPackageList(PackageList_MDL dboPackageList)
        //{
        //    tm.TableName = TABLENAME;
        //    tm.KeyColumnsName = new string[1] { fID };
        //    tm.IDTextList = dboPackageList.V_IDs;
        //    return objPreparer.ExecCancelCmd(tm);
        //}

        private IList<PackageList_MDL> getDataListOfItemMstr(StringBuilder sqlWhere, SqlParameter[] sqlParas)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY id");

            IList<PackageList_MDL> ItemMstrList = new List<PackageList_MDL>();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(CommandType.Text, sqlCmd.ToString(), sqlParas))
            {
                while (sdr.Read())
                {
                    PackageList_MDL ItemMstr = new PackageList_MDL(
                        (sdr["id"] == DBNull.Value) ? "0" : sdr["id"].ToString(),
                        (sdr["CompanyName"] == DBNull.Value) ? "0" : sdr["CompanyName"].ToString(),
                        (sdr["PN"] == DBNull.Value) ? "0" : sdr["PN"].ToString().Trim(),
                        (sdr["ProdNO"] == DBNull.Value) ? "0" : sdr["ProdNO"].ToString(),
                        (sdr["ProdName"] == DBNull.Value) ? "0" : sdr["ProdName"].ToString(),
                        (sdr["NumOfBox"] == DBNull.Value) ? "0" : sdr["NumOfBox"].ToString(),
                        (sdr["FileNO"] == DBNull.Value) ? "0" : sdr["FileNO"].ToString(),
                        (sdr["PackageNO"] == DBNull.Value) ? "0" : sdr["PackageNO"].ToString(),
                        (sdr["PackageModel"] == DBNull.Value) ? "0" : sdr["PackageModel"].ToString(),
                        (sdr["GlueBoxNo"] == DBNull.Value) ? "0" : sdr["GlueBoxNo"].ToString(),
                        (sdr["GlueBoxModel"] == DBNull.Value) ? "0" : sdr["GlueBoxModel"].ToString(),

                        (sdr["GluePackageModel"] == DBNull.Value) ? "0" : sdr["GluePackageModel"].ToString(),
                        (sdr["GluePackageNum"] == DBNull.Value) ? "0" : sdr["GluePackageNum"].ToString(),
                        (sdr["LongKnifeModel"] == DBNull.Value) ? "0" : sdr["LongKnifeModel"].ToString(),
                        (sdr["LongKnifeNum"] == DBNull.Value) ? "0" : sdr["LongKnifeNum"].ToString(),
                        (sdr["ShortKnifeModel"] == DBNull.Value) ? "0" : sdr["ShortKnifeModel"].ToString(),
                        (sdr["ShortKnifeNum"] == DBNull.Value) ? "0" : sdr["ShortKnifeNum"].ToString(),
                        (sdr["BlockOffCardModel"] == DBNull.Value) ? "0" : sdr["BlockOffCardModel"].ToString(),
                        (sdr["BlockOffCardNum"] == DBNull.Value) ? "0" : sdr["BlockOffCardNum"].ToString(),
                        (sdr["FlatCardModel"] == DBNull.Value) ? "0" : sdr["FlatCardModel"].ToString(),
                        (sdr["FlatCardNum"] == DBNull.Value) ? "0" : sdr["FlatCardNum"].ToString(),


                        (sdr["AbsorbPlasticModel"] == DBNull.Value) ? "0" : sdr["AbsorbPlasticModel"].ToString(),
                        (sdr["AbsorbPlasticNum"] == DBNull.Value) ? "0" : sdr["AbsorbPlasticNum"].ToString(),
                        (sdr["Notice"] == DBNull.Value) ? "0" : sdr["Notice"].ToString(),
                        (sdr["PagkagePhoto"] == DBNull.Value) ? null : (byte[])sdr["PagkagePhoto"],
                        (sdr["PagkagePhotoType"] == DBNull.Value) ? "0" : sdr["PagkagePhotoType"],
                        (sdr["PackageType"] == DBNull.Value) ? "0" : sdr["PackageType"].ToString(),
                        (sdr["CellLineNum"] == DBNull.Value) ? "0" : sdr["CellLineNum"].ToString(),
                        (sdr["LineNum"] == DBNull.Value) ? "0" : sdr["LineNum"].ToString(),
                        (sdr["CellPCS"] == DBNull.Value) ? "0" : sdr["CellPCS"].ToString(),
                        (sdr["BoxNum"] == DBNull.Value) ? "0" : sdr["BoxNum"].ToString(),
                        (sdr["TotalPCS"] == DBNull.Value) ? "0" : sdr["TotalPCS"].ToString(),

                        (sdr["CellBlockOff"] == DBNull.Value) ? "0" : sdr["CellBlockOff"].ToString(),
                        (sdr["FlatCard"] == DBNull.Value) ? "0" : sdr["FlatCard"].ToString(),
                        (sdr["NewVer"] == DBNull.Value) ? "0" : sdr["NewVer"].ToString(),
                        (sdr["ChangedVer"] == DBNull.Value) ? "0" : sdr["ChangedVer"].ToString(),
                        (sdr["EffectDate"] == DBNull.Value) ? "0" : sdr["EffectDate"].ToString(),
                        (sdr["NewOldChangedFlag"] == DBNull.Value) ? "0" : sdr["NewOldChangedFlag"].ToString(),
                        (sdr["NewOldVer"] == DBNull.Value) ? "0" : sdr["NewOldVer"].ToString(),
                        (sdr["OldType"] == DBNull.Value) ? "0" : sdr["OldType"].ToString(),
                        (sdr["OldType_BoxNum"] == DBNull.Value) ? "0" : sdr["OldType_BoxNum"].ToString(),
                        (sdr["OldType_Num"] == DBNull.Value) ? "0" : sdr["OldType_Num"].ToString(),

                        (sdr["OldType_CellNum"] == DBNull.Value) ? "0" : sdr["OldType_CellNum"].ToString(),
                        (sdr["OldType_BoxPCS"] == DBNull.Value) ? "0" : sdr["OldType_BoxPCS"].ToString(),
                        (sdr["OldType_GlueModel"] == DBNull.Value) ? "0" : sdr["OldType_GlueModel"].ToString(),
                        (sdr["OldType_Other"] == DBNull.Value) ? "0" : sdr["OldType_Other"].ToString(),
                        (sdr["TableMaker"] == DBNull.Value) ? "0" : sdr["TableMaker"].ToString(),
                        (sdr["Checker"] == DBNull.Value) ? "0" : sdr["Checker"].ToString(),
                        (sdr["EffectedDate"] == DBNull.Value) ? "0" : sdr["EffectedDate"].ToString(),
                        (sdr["QCChecker"] == DBNull.Value) ? "0" : sdr["QCChecker"].ToString(),
                        (sdr["VerNO"] == DBNull.Value) ? "0" : sdr["VerNO"].ToString(),
                        (sdr["TableNO"] == DBNull.Value) ? "0" : sdr["TableNO"].ToString()
                        );
                    ItemMstrList.Add(ItemMstr);
                }
            }
            return ItemMstrList;
        }

        private DataTable getDataListOfItemMstr(StringBuilder sqlWhere, SqlParameter[] sqlParas, int t)
        {
            string[] SELECT = new string[FieldName1.Length + FieldName2.Length];
            System.Array.Copy(FieldName1, 0, SELECT, 0, FieldName1.Length);
            System.Array.Copy(FieldName2, 0, SELECT, FieldName1.Length, FieldName2.Length);
            StringBuilder sqlCmd = new StringBuilder(fsc.GetSelectCmd(TableName, SELECT));

            sqlCmd.Append(sqlWhere);
            sqlCmd.Append(" ORDER BY id");

            IList<PackageList_MDL> ItemMstrList = new List<PackageList_MDL>();
            return SqlHelper.ReturnTableValue(CommandType.Text, sqlCmd.ToString(), sqlParas);

        }
    }
}
