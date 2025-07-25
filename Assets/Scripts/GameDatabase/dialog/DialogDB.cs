
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg.dialog
{
public sealed partial class DialogDB : Luban.BeanBase
{
    public DialogDB(JSONNode _buf) 
    {
        { if(!_buf["ID"].IsString) { throw new SerializationException(); }  ID = _buf["ID"]; }
        { if(!_buf["dialogTag"].IsString) { throw new SerializationException(); }  DialogTag = _buf["dialogTag"]; }
        { if(!_buf["name"].IsString) { throw new SerializationException(); }  Name = _buf["name"]; }
        { if(!_buf["text"].IsString) { throw new SerializationException(); }  Text = _buf["text"]; }
        { if(!_buf["nextID"].IsString) { throw new SerializationException(); }  NextID = _buf["nextID"]; }
        { if(!_buf["bgPath"].IsString) { throw new SerializationException(); }  BgPath = _buf["bgPath"]; }
        { if(!_buf["action"].IsString) { throw new SerializationException(); }  Action = _buf["action"]; }
        { var __json0 = _buf["choice"]; if(!__json0.IsArray) { throw new SerializationException(); } Choice = new System.Collections.Generic.Dictionary<string, string>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { string _k0;  { if(!__e0[0].IsString) { throw new SerializationException(); }  _k0 = __e0[0]; } string _v0;  { if(!__e0[1].IsString) { throw new SerializationException(); }  _v0 = __e0[1]; }  Choice.Add(_k0, _v0); }   }
    }

    public static DialogDB DeserializeDialogDB(JSONNode _buf)
    {
        return new dialog.DialogDB(_buf);
    }

    public readonly string ID;
    /// <summary>
    /// 对每一组对话的标识符
    /// </summary>
    public readonly string DialogTag;
    /// <summary>
    /// 说话者
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 文本
    /// </summary>
    public readonly string Text;
    /// <summary>
    /// 下一句话的ID
    /// </summary>
    public readonly string NextID;
    /// <summary>
    /// 背景图的路径
    /// </summary>
    public readonly string BgPath;
    public readonly string Action;
    /// <summary>
    /// 多分支
    /// </summary>
    public readonly System.Collections.Generic.Dictionary<string, string> Choice;
   
    public const int __ID__ = -818897460;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "ID:" + ID + ","
        + "dialogTag:" + DialogTag + ","
        + "name:" + Name + ","
        + "text:" + Text + ","
        + "nextID:" + NextID + ","
        + "bgPath:" + BgPath + ","
        + "action:" + Action + ","
        + "choice:" + Luban.StringUtil.CollectionToString(Choice) + ","
        + "}";
    }
}

}

