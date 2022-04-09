using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State3
{

    public enum StateEnum
    {
        OffHook,/// The condition that exists when a telephone or other user instrument is in use, i.e., during dialing or communicating.
        Connecting,
        Connected,
        OnHold
    }

    public enum Trigger
    {
        CallDialed,
        HangUp,
        CallConnected,
        PlanedOnHold,
        TakenOffHold,
        LeftMessage
    }

    public class Demo
    {
        public static Dictionary<StateEnum, List<(Trigger, StateEnum)>> rules = new Dictionary<StateEnum, List<(Trigger, StateEnum)>>
        {
            [StateEnum.OffHook] = new List<(Trigger, StateEnum)>
            {
                 (Trigger.CallDialed,StateEnum.Connecting )
            },
            [StateEnum.Connecting]= new List<(Trigger, StateEnum)>
            {
                (Trigger.HangUp,StateEnum.OffHook),
                (Trigger.CallConnected,StateEnum.Connected)
            },
            [StateEnum.Connected]= new List<(Trigger, StateEnum)>
            {
                (Trigger.LeftMessage,StateEnum.OffHook),
                (Trigger.HangUp,StateEnum.OffHook),
                (Trigger.PlanedOnHold,StateEnum.OnHold)
            },
            [StateEnum.OnHold] = new List<(Trigger, StateEnum)>
            {
                (Trigger.TakenOffHold,StateEnum.Connected),
                (Trigger.HangUp,StateEnum.OffHook)
            }
        };
    }
}
