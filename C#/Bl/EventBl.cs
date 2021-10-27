using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class EventBl
    {

        public static List<Dto.EventDto> GetEventsOfBuilding(int id_building)
        {
            return Dto.Convert.EventConvert.ConvertDalEntityToDto(
                Dal.EventDal.GetEventsOfBuilding(id_building));
        }

        public static void PostEvent(Dto.EventDto eventDto)
        {
            Dal.EventDal.PostEvent(
                Dto.Convert.EventConvert.ConvertDalDtoToEntity(eventDto));
        }

    }
}
