using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class EventConvert
    {
        public static List<EventDto> ConvertDalEntityToDto(List<Dal.experience> events)
        {
            if (events == null)
                return null;
            List<EventDto> EventDtos = events.Select(c => ConvertDalEntityToDto(c)).ToList();
            return EventDtos;

        }

        public static EventDto ConvertDalEntityToDto(Dal.experience events)
        {
            if (events is null)
                return null;
            EventDto eventDto = new EventDto()
            {
                id_experience = events.id_experience,
                event_date = events.event_date,
                title = events.title,
                event_building = events.event_building,
            };
            return eventDto;
        }


        public static Dal.experience ConvertDalDtoToEntity(EventDto eventDto)
        {
            try
            {
                Dal.experience events = new Dal.experience()
                {
                    id_experience = eventDto.id_experience,
                    event_date = eventDto.event_date,
                    title = eventDto.title,
                    event_building = eventDto.event_building,
                };
                return events;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
