
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg.schedule
{
public sealed partial class Course : DateAction
{
    public Course(JSONNode _buf)  : base(_buf) 
    {
        { var __json0 = _buf["IndexChange"]; if(!__json0.IsArray) { throw new SerializationException(); } IndexChange = new System.Collections.Generic.Dictionary<string, int>(__json0.Count); foreach(JSONNode __e0 in __json0.Children) { string _k0;  { if(!__e0[0].IsString) { throw new SerializationException(); }  _k0 = __e0[0]; } int _v0;  { if(!__e0[1].IsNumber) { throw new SerializationException(); }  _v0 = __e0[1]; }  IndexChange.Add(_k0, _v0); }   }
        { if(!_buf["MoneyReduce"].IsNumber) { throw new SerializationException(); }  MoneyReduce = _buf["MoneyReduce"]; }
    }

    public static Course DeserializeCourse(JSONNode _buf)
    {
        return new schedule.Course(_buf);
    }

    public readonly System.Collections.Generic.Dictionary<string, int> IndexChange;
    public readonly int MoneyReduce;
   
    public const int __ID__ = -162982030;
    public override int GetTypeId() => __ID__;

    public override void ResolveRef(Tables tables)
    {
        base.ResolveRef(tables);
    }

    public override string ToString()
    {
        return "{ "
        + "IndexChange:" + Luban.StringUtil.CollectionToString(IndexChange) + ","
        + "MoneyReduce:" + MoneyReduce + ","
        + "}";
    }
}

}

