=== Elder ==
{ElderQuest_Yes: ->ElderQuest_running}
{ElderQuest.decline: ->ElderQuest_Again}
->ElderQuest
=ElderQuest
Elder: Hey there.
Could you do me a favor ?
Josh: Sure !
How can i help you ?
Elder: Can you make us a Campfire so we can eat some Food ?
* [Yes i can !] ->ElderQuest_Yes
* (decline) [No not yet.] ->END

=ElderQuest_Yes
Elder: Great !
You should start by gathering some small Stones.
~ Unity_Event("Quest_Stones_Start")

->END

=ElderQuest_Again
Elder: Have you changed your mind ?
+ [Yes im ready now.] ->ElderQuest_Yes
+ [No] 

->END

=ElderQuest_running
{Get_State("item_Stones") > 1: ->fulfilled|-> followUpFalse}


->END
=fulfilled
Elder: Great.
You have found all Stones !
~ Unity_Event("SetActive_Stones")
->END

=followUpFalse
Elder: You dont have enough Stones yet.
Keep on searching !

->END