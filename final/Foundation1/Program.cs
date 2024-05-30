using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videosList = new List<Video>();

        // Video 1
        Video video1 = new Video("Living in the Heart of Brazil: Exploring the Amazon rainforest", "Marcos Chafla", 480);

        Comment video1Comment1 = new Comment("Matheus", "This video is really inspiring! I love how you explore the Amazon rainforest and share its story.");
        Comment video1Comment2 = new Comment("Lucas", "Your content always surprises me. I'm glad you're showcasing the beauty of our country.");
        Comment video1Comment3 = new Comment("Marta", "Wonderful! I would love to visit those places someday.");

        video1.ListComment(video1Comment1);
        video1.ListComment(video1Comment2);
        video1.ListComment(video1Comment3);

        videosList.Add(video1);

        // Video 2
        Video video2 = new Video("Brazil, the new world", "Ben tew", 975);

        Comment video2Comment1 = new Comment("Diego", "What an incredible adventure! I love how you show Brazil and invite us to discover more about our history.");
        Comment video2Comment2 = new Comment("camille", "Your videos always transport me to new places. Thank you for sharing these hidden gems.");
        Comment video2Comment3 = new Comment("roberta", "The views are simply stunning. I'm proud to be Brazilian.");

        video2.ListComment(video2Comment1);
        video2.ListComment(video2Comment2);
        video2.ListComment(video2Comment3);

        videosList.Add(video2);

        // Video 3
        Video video3 = new Video("Brazilian Cuisine: A Gastronomic Adventure", "Matheus Nobrega", 650);

        Comment video3Comment1 = new Comment("Fábio", "My mouth was watering while watching this video! Our cuisine is truly unique and delicious.");
        Comment video3Comment2 = new Comment("Rebeca", "I love feijoada!");
        Comment video3Comment3 = new Comment("Fred", "Brazilian food is famous worldwide, and your videos perfectly capture its essence.");

        video3.ListComment(video3Comment1);
        video3.ListComment(video3Comment2);
        video3.ListComment(video3Comment3);

        videosList.Add(video3);

        foreach (Video video in videosList)
        {
            video.DisplayInfo();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}