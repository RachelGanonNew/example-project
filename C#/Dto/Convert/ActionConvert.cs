using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class ActionConvert
    {
        public static List<ActionDto> ConvertDalEntityToDto(List<Dal.Action> actions)
        {
            if (actions == null)
                return null;
            List<ActionDto> actionDtos = actions.Select(a => ConvertDalEntityToDto(a)).ToList();
            return actionDtos;

        }

        public static ActionDto ConvertDalEntityToDto(Dal.Action action)
        {
            if (action is null)
                return null;
            ActionDto actionDto = new ActionDto()
            {
                id_action = action.id_action,
                kind_of_action = action.kind_of_action,
                action_description = action.action_description,
                action_date = action.action_date,
                action_sum = action.action_sum,
                id_tenant = action.id_tenant,
                id_building = action.id_building,
                id_action_category = action.id_action_category
            };


            return actionDto;

        }


        public static Dal.Action ConvertDalDtoToEntity(ActionDto actionDto)
        {
            try
            {
                Dal.Action action = new Dal.Action()
                {
                    id_action = actionDto.id_action,
                    kind_of_action = actionDto.kind_of_action,
                    action_description = actionDto.action_description,
                    action_date = actionDto.action_date,
                    action_sum = actionDto.action_sum,
                    id_tenant = actionDto.id_tenant,
                    id_building = actionDto.id_building,
                    id_action_category = actionDto.id_action_category
                };
                return action;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
