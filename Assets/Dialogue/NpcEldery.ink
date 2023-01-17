=== Elder ===
{fulfilled: ->ElderQuest_running}
{ElderQuest_Yes: ->ElderQuest_running}
{ElderQuest.decline: ->ElderQuest_Again}
->ElderQuest
=ElderQuest
Elder: Hey Utaka !
Can you do me a favor ?
Utaka: Sure !
How can i help you ?
Elder: Its pretty cold today.
Could you make a Fire for us ?
* [Yes i can !] ->ElderQuest_Yes
* (decline) [No not yet.] ->END

=ElderQuest_Yes
Elder: Great !
First you need to find a way to make small Stones for the Fireplace.
~ Unity_Event("Quest_Stones_Start")

->END

=ElderQuest_Again
Elder: Have you changed your mind ?
+ [Im ready now.] ->ElderQuest_Yes
+ [No] 

->END

=ElderQuest_running
{Get_State("item_Stones") > 1: ->fulfilled|-> followUpFalse}


->END

=fulfilled
Elder: Great.
You have found all Stones !
~ Unity_Event("SetActive_Stones")
Elder: Now you should collect firewood
->fulfilled2
~ Unity_Event("Firewood_Quest")


=fulfilled2
Elder: blblblb
{Get_State("Firewood") > 2: ->fulfilled3|-> followUpFalse2}


->END

=followUpFalse
Elder: You dont have enough Stones yet. 
Maybe you could push a big Stone over a Cliff, it might shatter into smaller pieces.

->END

=followUpFalse2
Elder: You dont have enough Wood yet.

->END

=fulfilled3
Elder: Now you should talk to your Brother.
~ Unity_Event("ActivateRiver_Quest")

->END




