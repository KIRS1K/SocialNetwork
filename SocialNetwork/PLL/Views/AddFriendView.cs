using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        AddFriendService addFriendService;
        public AddFriendView (AddFriendService addFriendService1)
        {
            this.addFriendService = addFriendService1;
        }
        public void Show(User user)
        {
            var addFriendData = new AddFriendData();
            Console.WriteLine("Ваш Id: " + user.Id);
            Console.Write("Введите Id друга: ");
            string proverka = Console.ReadLine();
            addFriendData.friend_id = Convert.ToInt32(proverka);
            addFriendData.user_id = user.Id;
            try
            {
                this.addFriendService.AddFriend(addFriendData);
                SuccessMessage.Show("Друг успешно добавлен.");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }

            catch (Exception en)
            {
                AlertMessage.Show("Произошла ошибка при операции:");
                Console.WriteLine(en);
                Console.ReadKey();
            }
        }
    }
}
