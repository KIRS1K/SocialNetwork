using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class AddFriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public AddFriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void AddFriend(AddFriendData addFriendData) 
        {
            if (String.IsNullOrEmpty(Convert.ToString(addFriendData.user_id)))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(Convert.ToString(addFriendData.user_id)))
                throw new ArgumentNullException();

            if (userRepository.FindById(addFriendData.user_id) == null)
                throw new UserNotFoundException();

            if (userRepository.FindById(addFriendData.friend_id) == null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = addFriendData.user_id,
                friend_id = addFriendData.friend_id,
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new ArgumentNullException();

        }
    }
}
