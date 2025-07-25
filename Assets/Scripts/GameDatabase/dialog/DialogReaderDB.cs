
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
public partial class DialogReaderDB
{
    private readonly System.Collections.Generic.Dictionary<string, dialog.DialogDB> _dataMap;
    private readonly System.Collections.Generic.List<dialog.DialogDB> _dataList;
    
    public DialogReaderDB(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<string, dialog.DialogDB>();
        _dataList = new System.Collections.Generic.List<dialog.DialogDB>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            dialog.DialogDB _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = global::cfg.dialog.DialogDB.DeserializeDialogDB(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
    }

    public System.Collections.Generic.Dictionary<string, dialog.DialogDB> DataMap => _dataMap;
    public System.Collections.Generic.List<dialog.DialogDB> DataList => _dataList;

    public dialog.DialogDB GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public dialog.DialogDB Get(string key) => _dataMap[key];
    public dialog.DialogDB this[string key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

