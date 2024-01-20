using System.Collections.Generic;

abstract class AbilityInfo : JsonSerializable
{
    protected string name;
    protected string desc;
    protected List<string> types;

    protected double damage;
    protected double heal;
    protected double shield;
    protected List<Status> statusIncoming;
    protected List<Status> statusOutgoing;

    protected int duration;
    protected TargetRange target;
}