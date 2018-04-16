using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
//using System.IComparable;

class HighScore : System.IComparable<HighScore>
{
    public int Score { get; set; }
    public string Username { get; set; }

    public int ID { get; set; }

    public int Level { get; set; }

    public HighScore(int id, int score, string username, int level)
    {
        this.ID = id;
        this.Score = score;
        this.Username = username;
        this.Level = level;

    }

    

    public int CompareTo(HighScore other)
    {
      if(other.Score < this.Score)
        {
            return -1;
        }

      else if(other.Score > this.Score)
        {
            return 1;
        }

         else if(other.ID <  this.ID)
           {
            return -1;
           }

      else if(other.ID > this.ID)
        {
            return 1;
        }
        return 0;


    }
}
