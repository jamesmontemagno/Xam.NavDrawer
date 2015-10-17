using System.Collections.Generic;

using NavDrawer.Models;

namespace NavDrawer.Adapters
{
    public static class Util
    {
        public static List<FriendViewModel> GenerateFriends()
        {
            return new List<FriendViewModel>
            {
                new FriendViewModel
                {
                    Title = "Japanese Macaque",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/cache/japanese-macaque_589_990x742.jpg",
                },
                new FriendViewModel
                {
                    Title = "Golden Lion Tamarin",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/cache/golden-lion-tamarin_552_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Mandrill",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/cache/mandrill_622_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Gelada Monkeys",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/cache/gelada-baboons_536_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Howler Monkey",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/004/cache/black-howler-monkey_467_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Spider Monkey",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/007/cache/spider-monkey_719_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Rhesus Monkey",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/cache/rhesus-monkey_684_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Vervet Monkeys",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/vervet-monkey_6458_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Olive Baboons",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/cache/olive-baboon_649_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Squirrel Monkey",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/squirrel-monkey_6457_990x742.jpg"
                },
                new FriendViewModel
                {
                    Title = "Proboscis Monkey",
                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/proboscis-monkey_6456_990x742.jpg"
                }
            };
        }
    }
}