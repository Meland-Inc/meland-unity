//------------------------------------------------------------
// 此文件由工具自动生成
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;


/// <summary>
/** __DATA_TABLE_COMMENT__*/
/// </summary>
public class DRLessonMode : DataRowBase
{
    private int _id = 0;

    /// <summary>
    /// /**获取ID。*/
    /// </summary>
    public override int Id => _id;

    /// <summary>
  /**获取课程模式名。*/
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
  /**获取教师上课默认状态。*/
    /// </summary>
    public bool TeacherDefaultState
    {
        get;
        private set;
    }

    /// <summary>
  /**获取演示/查看模式UI。*/
    /// </summary>
    public bool DemoViewModeUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取锁屏UI。*/
    /// </summary>
    public bool LockScreenUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取学生指引UI。*/
    /// </summary>
    public bool StudentGuideUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取学生管理UI。*/
    /// </summary>
    public bool StudentManageUI
    {
        get;
        private set;
    }

    /// <summary>
  /**获取学生传送。*/
    /// </summary>
    public bool StudentTransfer
    {
        get;
        private set;
    }

    /// <summary>
  /**获取音乐。*/
    /// </summary>
    public bool Bgm
    {
        get;
        private set;
    }

    /// <summary>
  /**获取音效。*/
    /// </summary>
    public bool SoundEffect
    {
        get;
        private set;
    }

    /// <summary>
  /**获取点击寻路。*/
    /// </summary>
    public bool PathFinding
    {
        get;
        private set;
    }

    /// <summary>
  /**获取摇杆移动。*/
    /// </summary>
    public bool RockerMove
    {
        get;
        private set;
    }

    /// <summary>
  /**获取窗口化。*/
    /// </summary>
    public bool WindowMode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取镜头模式。*/
    /// </summary>
    public string CameraMode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取操作模式。*/
    /// </summary>
    public string OperateMode
    {
        get;
        private set;
    }

    /// <summary>
  /**获取场景解锁开关。*/
    /// </summary>
    public bool SceneUnlock
    {
        get;
        private set;
    }

    /// <summary>
  /**获取地图入口开关。*/
    /// </summary>
    public bool MapEntrace
    {
        get;
        private set;
    }

    /// <summary>
  /**获取流程管理UI。*/
    /// </summary>
    public bool LessonManageUI
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = CSVSerializer.ParseCSVCol(dataRowString);

        int index = 0;
        _id = int.Parse(columnStrings[index++]);
        Name = columnStrings[index++];
        TeacherDefaultState = DataTableParseUtil.ParseBool(columnStrings[index++]);
        DemoViewModeUI = DataTableParseUtil.ParseBool(columnStrings[index++]);
        LockScreenUI = DataTableParseUtil.ParseBool(columnStrings[index++]);
        StudentGuideUI = DataTableParseUtil.ParseBool(columnStrings[index++]);
        StudentManageUI = DataTableParseUtil.ParseBool(columnStrings[index++]);
        StudentTransfer = DataTableParseUtil.ParseBool(columnStrings[index++]);
        Bgm = DataTableParseUtil.ParseBool(columnStrings[index++]);
        SoundEffect = DataTableParseUtil.ParseBool(columnStrings[index++]);
        PathFinding = DataTableParseUtil.ParseBool(columnStrings[index++]);
        RockerMove = DataTableParseUtil.ParseBool(columnStrings[index++]);
        WindowMode = DataTableParseUtil.ParseBool(columnStrings[index++]);
        CameraMode = columnStrings[index++];
        OperateMode = columnStrings[index++];
        SceneUnlock = DataTableParseUtil.ParseBool(columnStrings[index++]);
        MapEntrace = DataTableParseUtil.ParseBool(columnStrings[index++]);
        LessonManageUI = DataTableParseUtil.ParseBool(columnStrings[index++]);

        return true;
    }


    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new(memoryStream, Encoding.UTF8))
            {
                _id = binaryReader.Read7BitEncodedInt32();
                Name = binaryReader.ReadString();
                TeacherDefaultState = binaryReader.ReadBoolean();
                DemoViewModeUI = binaryReader.ReadBoolean();
                LockScreenUI = binaryReader.ReadBoolean();
                StudentGuideUI = binaryReader.ReadBoolean();
                StudentManageUI = binaryReader.ReadBoolean();
                StudentTransfer = binaryReader.ReadBoolean();
                Bgm = binaryReader.ReadBoolean();
                SoundEffect = binaryReader.ReadBoolean();
                PathFinding = binaryReader.ReadBoolean();
                RockerMove = binaryReader.ReadBoolean();
                WindowMode = binaryReader.ReadBoolean();
                CameraMode = binaryReader.ReadString();
                OperateMode = binaryReader.ReadString();
                SceneUnlock = binaryReader.ReadBoolean();
                MapEntrace = binaryReader.ReadBoolean();
                LessonManageUI = binaryReader.ReadBoolean();
            }
        }

        return true;
    }
}

