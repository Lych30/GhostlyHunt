using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

    public class check : MonoBehaviour
    {
        private Transform[] attaches;
        //[SerializeField] GameObject GPS;
        private SpriteRenderer sr;
        private Animator anim;
        AIPath _ai;
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            var gg = AstarPath.active.data.gridGraph;
            _ai = GetComponent<AIPath>();

            //CHECK DE TOUTES LES NODES SI BESOINS
            /*for (int z = 0; z < gg.depth; z++)
            {
                for (int x = 0; x < gg.width; x++)
                {

                }
            }*/

        }
        private void Update()
        {
            anim.SetFloat("VelocityX", Mathf.Abs(_ai.velocity.x));
            anim.SetFloat("VelocityY", _ai.velocity.y);
            if (Mathf.Abs(_ai.velocity.x) > Mathf.Abs(_ai.velocity.y))
            {
                
                if (_ai.velocity.x > 0)
                {
                    sr.flipX = false;
                }
                else
                {
                    sr.flipX = true;
                }
            }
        /*if (_ai.reachedEndOfPath)
        {
        if (GPS.GetComponent<GooglePlayGamesManager>().IsConnectedToGPS)
        {
            Social.ReportProgress(GPGSIds.achievement_cheers_you_lost, 100.0f, null);
        }
    }*/

    }



    }


