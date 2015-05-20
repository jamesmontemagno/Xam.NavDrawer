using System.Collections.Generic;

using NavDrawer.Models;

namespace NavDrawer.Adapters
{
    public static class Util
    {
        public static List<Friend> GenerateFriends()
        {
            return new List<Friend>
                        {
                new Friend
                                {
                                    Title = "Japanese Macaque",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/japanese-macaque_589_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Golden Lion Tamarin",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/golden-lion-tamarin_552_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Mandrill",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/mandrill_622_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Gelada Monkeys",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/005/overrides/gelada-baboons_536_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Howler Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/004/overrides/black-howler-monkey_467_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Spider Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/007/overrides/spider-monkey_719_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Rhesus Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/rhesus-monkey_684_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Vervet Monkeys",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/vervet-monkey_6458_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Olive Baboons",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/006/overrides/olive-baboon_649_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Squirrel Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/squirrel-monkey_6457_100x75.jpg"
                                },
                            new Friend
                                {
                                    Title = "Proboscis Monkey",
                                    Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/064/cache/proboscis-monkey_6456_100x75.jpg"
                                }
                        };
        }
    }
}