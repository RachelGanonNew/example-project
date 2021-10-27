using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Convert
{
    public class VoteConvert
    {
        public static List<VoteDto> ConvertDalEntityToDto(List<Dal.Vote> votes)
        {
            List<VoteDto> voteDtos = votes.Select(v => ConvertDalEntityToDto(v)).ToList();
            return voteDtos;
        }

        public static VoteDto ConvertDalEntityToDto(Dal.Vote vote)
        {
            try {
                if (vote is null)
                    return null;
                Dictionary<int, int> tenants_vote_dict = new Dictionary<int, int>();
                if (!(String.IsNullOrEmpty(vote.tenants_vote)))
                {
                    string[] splitted = vote.tenants_vote.Split(',');
                    for (int i = 0; i < splitted.Length; i += 2) {
                        tenants_vote_dict.Add(int.Parse(splitted[i]), int.Parse(splitted[i + 1]));
                    }
                }
                VoteDto voteDto = new VoteDto()
                {
                    id_vote = vote.id_vote,
                    id_meeting = vote.id_meeting,
                    vote_subject = vote.vote_subject,
                    vote_description = vote.vote_description,
                    tenants_vote = tenants_vote_dict,
                    id_building = vote.id_building,
                    id_tenant= vote.id_tenant
                };
                return voteDto;
            }
            catch (Exception e){
                return null;
            }
        }

        public static Dal.Vote ConvertDalDtoToEntity(VoteDto voteDto)
        {
            try{
                //StringBuilder s = new StringBuilder();
                //foreach (KeyValuePair<int, int> ele1 in voteDto.tenants_vote)
                //{ 
                //    s.Append("," + ele1.Key + "," + ele1.Value);
                //}
                Dal.Vote vote = new Dal.Vote()
                {
                    id_vote = voteDto.id_vote,
                    id_meeting = voteDto.id_meeting,
                    vote_subject = voteDto.vote_subject,
                    vote_description = voteDto.vote_description,
                    //tenants_vote = s.ToString().Substring(1),
                    tenants_vote = null,
                    id_building = voteDto.id_building,

                };
                return vote;
            }
            catch (Exception e){
                return null;
            }
        }









    }
}
