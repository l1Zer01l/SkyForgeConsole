/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public interface IEvent
    {
        bool IsHandled { get; }
        EventType GetEventType();
        bool IsEventCategory(EventCategory eventCategory);
    }
}
