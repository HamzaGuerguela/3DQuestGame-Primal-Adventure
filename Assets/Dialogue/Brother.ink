=== Brother ===
// Das nächste mal wenn man mit diesem npc redet soll BrotherQuest_running geprüft werden.
{????: ->BrotherQuest_running}
= BrotherStart
Brother: Hey Utaka ! I see, you need to know where to find Firestones right ?
Utaka: Yes thats right !
Brother: There should be Firestones in the Cave on the other Site of the water.
~ Unity_Event("Quest_Firestones_Start")
Utaka: But how am i supposed to get there ?
Brother: You need to find a Spot near the Water from where you can jump over it. 
Utaka: Alright i will try my best !
~ Unity_Event("Quest_River_Start")

->END




=BrotherQuest_running
{Get_State("Firestones") > 1: ->fulfilledBrother|->followUpFalseBrother}

->END




->fulfilledBrother
Brother: Good job you actually made it !
Brother: Your last task will be to finally light up the fire.
~ Unity_Event("Quest_Fire_Start")
Utaka: Great ! Thanks for all your help Brother.
~ Unity_Event("Brother_completed")

->END




->followUpFalseBrother
Brother: I think a good place to jump over the water would be near the rock.
Brother: And remeber to pick up 2 Firestones.
Utaka: Okay thanks for you advice !

->END

