/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public class MouseEvent : Event
    {
        public MouseEvent(EventType eventType, EventCategory eventCategory = EventCategory.None) 
               : base(eventType, eventCategory | EventCategory.MouseEvent)
        {

        }
    }
}
