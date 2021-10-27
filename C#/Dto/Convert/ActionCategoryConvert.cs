using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class ActionCategoryConvert
    {


        public static List<ActionCategoryDto> ConvertDalEntityToDto(List<Dal.Action_Category> action_Categories)
        {
            if (action_Categories == null)
                return null;
            List<ActionCategoryDto> actionCategortDtos = action_Categories.Select(a => ConvertDalEntityToDto(a)).ToList();
            return actionCategortDtos;

        }

        public static ActionCategoryDto ConvertDalEntityToDto(Dal.Action_Category action_Category)
        {
            if (action_Category is null)
                return null;

            ActionCategoryDto actionCategortDto = new ActionCategoryDto()
            {
                id_action_category = action_Category.id_action_category,
                action_category_description = action_Category.action_category_description,
                id_building = action_Category.id_building
            };
            return actionCategortDto;

        }


        public static Dal.Action_Category ConvertDalDtoToEntity(ActionCategoryDto actionCategoryDto)
        {
            try{
                Dal.Action_Category action_Category = new Dal.Action_Category()
                {
                    id_action_category = actionCategoryDto.id_action_category,
                    action_category_description = actionCategoryDto.action_category_description,
                    id_building = actionCategoryDto.id_building
                };
                return action_Category;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
