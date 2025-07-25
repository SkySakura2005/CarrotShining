
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg.cardGame
{
public sealed partial class EmotionCardDB : Luban.BeanBase
{
    public EmotionCardDB(JSONNode _buf) 
    {
        { if(!_buf["ID"].IsString) { throw new SerializationException(); }  ID = _buf["ID"]; }
        { if(!_buf["name"].IsString) { throw new SerializationException(); }  Name = _buf["name"]; }
        { if(!_buf["action"].IsString) { throw new SerializationException(); }  Action = _buf["action"]; }
        { if(!_buf["effectDescription"].IsString) { throw new SerializationException(); }  EffectDescription = _buf["effectDescription"]; }
        { if(!_buf["limitDescription"].IsString) { throw new SerializationException(); }  LimitDescription = _buf["limitDescription"]; }
        { if(!_buf["rank"].IsString) { throw new SerializationException(); }  Rank = _buf["rank"]; }
        { if(!_buf["iconPath"].IsString) { throw new SerializationException(); }  IconPath = _buf["iconPath"]; }
        { if(!_buf["rare"].IsNumber) { throw new SerializationException(); }  Rare = (cardGame.RareType)_buf["rare"].AsInt; }
    }

    public static EmotionCardDB DeserializeEmotionCardDB(JSONNode _buf)
    {
        return new cardGame.EmotionCardDB(_buf);
    }

    /// <summary>
    /// 卡牌ID
    /// </summary>
    public readonly string ID;
    /// <summary>
    /// 卡牌名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 触发效果的动作与限制判断命令
    /// </summary>
    public readonly string Action;
    /// <summary>
    /// 效果说明
    /// </summary>
    public readonly string EffectDescription;
    /// <summary>
    /// 使用限制说明
    /// </summary>
    public readonly string LimitDescription;
    /// <summary>
    /// 评价文本
    /// </summary>
    public readonly string Rank;
    /// <summary>
    /// 图标路径
    /// </summary>
    public readonly string IconPath;
    /// <summary>
    /// 稀有度
    /// </summary>
    public readonly cardGame.RareType Rare;
   
    public const int __ID__ = 1334613469;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "ID:" + ID + ","
        + "name:" + Name + ","
        + "action:" + Action + ","
        + "effectDescription:" + EffectDescription + ","
        + "limitDescription:" + LimitDescription + ","
        + "rank:" + Rank + ","
        + "iconPath:" + IconPath + ","
        + "rare:" + Rare + ","
        + "}";
    }
}

}

