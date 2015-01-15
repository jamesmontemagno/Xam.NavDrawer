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
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/japanese-macaque_589_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Golden Lion Tamarin",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/golden-lion-tamarin_552_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Mandrill",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/mandrill_622_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Gelada Monkeys",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/gelada-baboons_536_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Howler Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/004/overrides/black-howler-monkey_467_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Spider Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/007/overrides/spider-monkey_719_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Rhesus Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/rhesus-monkey_684_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Vervet Monkeys",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/vervet-monkey_6458_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Olive Baboons",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/olive-baboon_649_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Squirrel Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/squirrel-monkey_6457_100x75.jpg"
                                },
                            new FriendViewModel
                                {
                                    Title = "Proboscis Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/proboscis-monkey_6456_100x75.jpg"
                                }
                        };
        }
    }
}