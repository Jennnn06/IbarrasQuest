using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public List<KabanataData> kabanata64;
    public List<QuestDescription> questDescriptions;
    public int currentKabanata;

    public QuestData(int chapterCount)
    {
        kabanata64 = new List<KabanataData>();

        // Initialize completion status for each chapter
        for (int i = 0; i < chapterCount; i++)
        {
            kabanata64.Add(new KabanataData());
        }

        currentKabanata = 1;

        // Initialize quest descriptions
        questDescriptions = new List<QuestDescription>
        {
            //1-10
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Pumunta sa hapagkainan ni Kapitan Tiyago"),
            new QuestDescription("Kausapin si Tenyente Guevarra sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Kumain sa Fonda De Lala"),
            new QuestDescription("Kausapin si Kapitan Tiyago"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Sumakay sa kalesa sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Puntahan si Maria Clara sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Sumakay sa kalesa sa bahay ni Kapitan Tiyago"),
            // Add descriptions for the remaining quests

            //11-20
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Pumunta sa sementeryo, dumaan sa gilid ng simbahan"),
            new QuestDescription("Pumunta sa sementeryo, dumaan sa gilid ng simbahan"),
            new QuestDescription("Mag-alay ng bulaklak sa nitso, sa tabi ng simbahan"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Pumunta sa bahay ni Sisa"),
            new QuestDescription("Pumunta sa bahay ni Sisa"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Lumabas ng bahay para pumunta sa lawa"),
            new QuestDescription("Pumunta sa Tribunal"),

            //21-30
            new QuestDescription("Pumunta sa bahay ni Sisa"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Pumunta sa simbahan"),

            //31-40
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Kausapin si Elias sa gubat"),
            new QuestDescription("Pumunta sa kusina ni Kapitan Tiyago"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            new QuestDescription("Kausapin si Kapitan Heneral sa Bahay ni Kapitan Tiyago"),
            new QuestDescription("Pumunta sa simbahan"),
            new QuestDescription("Pumunta sa bahay ni Donya Consolacion"),
            new QuestDescription("Hanapin ang kartel na naglalaman ng cutscene sa gubat"),

            //41-50
            //1
            new QuestDescription("Pumunta sa labas ng bahay"),
            //2
            new QuestDescription("Pumunta sa bahay ni Donya Consolacion"),
            //3
            new QuestDescription("Pumunta sa bahay ni Donya Consolacion"),
            //4
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            //5
            new QuestDescription("Kausapin si Elias sa Gubat"),
            //6
            new QuestDescription("Kausapin si Elias sa Gubat"),
            //7
            new QuestDescription("Pumunta sa bahay ni Donya Consolacion"),
            //8
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            //9
            new QuestDescription("Pumunta sa ilog"),
            //10
            new QuestDescription("Pumunta sa ilog"),

            //51-60
            //1
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            //2
            new QuestDescription("Pumunta sa sementeryo, dumaan sa gilid ng simbahan"),
            //3
            new QuestDescription("Pumunta sa bahay ni Pilosopong Tasyo"),
            //4
            new QuestDescription("Pumunta sa bahay ni Donya Consolacion"),
            //5
            new QuestDescription("Pumunta sa kusina ni Kapitan Tiyago"),
            //6
            new QuestDescription("Kausapin si Elias sa Gubat"),
            //7
            new QuestDescription("Pumunta sa Kwartel"),
            //8
            new QuestDescription("Kausapin si Elias sa Gubat"),
            //9
            new QuestDescription("Pumunta sa simbahan"),
            //10
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),

            //61-64
            //1
            new QuestDescription("Pumunta sa ilog"),
            //2
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            //3
            new QuestDescription("Pumunta sa bahay ni Kapitan Tiyago"),
            //4
            new QuestDescription("Puntahan si Maria Clara sa bahay ni Kapitan Tiyago"),
        };
    }
}

[System.Serializable]
public class KabanataData
{
    public bool questCompleted;
    public bool quizCompleted;

    public KabanataData()
    {
        questCompleted = false;
        quizCompleted = false;
    }

}

[System.Serializable]
public class QuestDescription{
    public string description;

    public QuestDescription(string desc)
    {
        description = desc;
    }
}

[System.Serializable]
public class QuizQuestion{
    public string question;
    public List<string> answers;
    public int correctAnswerIndex;
}

