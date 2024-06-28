/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Events
{
    public abstract class Event : IEvent
    {
        public bool IsHandled => m_isHandled;

        protected bool m_isHandled;

        private EventType m_eventType;
        private EventCategory m_eventCategory;
        public Event(EventType eventType, EventCategory eventCategory)
        {
            m_eventType = eventType;
            m_eventCategory = eventCategory;
        }
        public EventType GetEventType()
        {
            return m_eventType;
        }

        public bool IsEventCategory(EventCategory eventCategory)
        {
            return (m_eventCategory & eventCategory) == eventCategory;
        }
    }
}
