
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using OfficeOpenXml;
using UnityEditor;
using Unity.VisualScripting;


public class UnitXls : MonoBehaviour
{
    public static MostData_SO mostData_So;
    //[MenuItem("Excel/Read Excel")]
    public static void ReadMostExcel()
    {
        mostData_So = Resources.Load<MostData_SO>("SO/MostData_So");
        if (mostData_So == null)
        {
            Debug.Log("加载失败" + mostData_So);
        }
        Dictionary<int, IndividualData> dic = LoadExcelAsDictionary(6, Application.dataPath + "/Excel/MostData.xlsx");
        foreach (var item in dic)
        {

            MostData most = mostData_So.mostdataList.Find(i => i.Id == item.Key);
            IndividualData individualData = item.Value;
            if (most != null)
            {
                most.Id = item.Key;
                most.hp = Convert.ToSingle(individualData.Values[1].ToString());
                most.potralSpeed = Convert.ToSingle(individualData.Values[2].ToString());
                most.rushSpeed = Convert.ToSingle(individualData.Values[3].ToString());
                most.dashforce = Convert.ToSingle(individualData.Values[4].ToString());
                most.hitforce = Convert.ToSingle(individualData.Values[5].ToString());
            }
            else
            {
                most = new MostData();
                most.Id = item.Key;
                most.hp = Convert.ToSingle(individualData.Values[1].ToString());
                most.potralSpeed = Convert.ToSingle(individualData.Values[2].ToString());
                most.rushSpeed = Convert.ToSingle(individualData.Values[3].ToString());
                most.dashforce = Convert.ToSingle(individualData.Values[4].ToString());
                most.hitforce = Convert.ToSingle(individualData.Values[5].ToString());
                mostData_So.mostdataList.Add(most);
            }
        }
       // AssetDatabase.SaveAssets();
    }
     
    public static Dictionary<int, IndividualData> LoadExcelAsDictionary(int CountOfAttributes,string path)
    {
        Dictionary<int, IndividualData> ItemDictionary = new Dictionary<int, IndividualData>();//新建字典，用于存储以行为单位的各个操作单元


        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//建立文件流fs
        
        ExcelPackage excel = new ExcelPackage(fs);

        ExcelWorksheets workSheets = excel.Workbook.Worksheets;//获取全部工作表

        ExcelWorksheet workSheet = workSheets[0];//只看第一个工作表，余者不看
        if (workSheet.Dimension == null)
        {
            Debug.Log("11111");
        }
        int colCount = workSheet.Dimension.End.Column;//工作表的列数
        int rowCount = workSheet.Dimension.End.Row;//工作表的行数

        for (int row = 2; row <= rowCount; row++)//从当前工作表的第二行遍历到最后一行(第一行是表头，所以不读取)
        {
            IndividualData item = new IndividualData(CountOfAttributes);//新建一个操作单元，开始接收本行数据

            for (int col = 1; col <= colCount; col++)//从第一列遍历到最后一列
            {
                //读取每个单元格中的数据
                item.Values[col - 1] = workSheet.Cells[row, col].Text;//将单元格中的数据写入操作单元
            }

            int itemID = Convert.ToInt32(item.Values[0].ToString());//获取操作单元的ID

            ItemDictionary.Add(itemID, item);//将ID和操作单元写入字典
        }

       
        return ItemDictionary;
    }

    
}
