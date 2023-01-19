=== Elder ===
{fulfilled4: ->checkWood2}
{fulfilled2: ->checkWood}
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
Elder: Great you have found all Stones !
~ Unity_Event("SetActive_Stones")
->fulfilled2


=fulfilled2
Elder: Now you should find some firewood.
Utaka: Alright will do !
~ Unity_Event("Firewood_Quest")
->END





=checkWood

{Get_State("Firewood") > 2: ->fulfilled3|-> followUpFalse2}

->END

=checkWood2

{Get_State("Firewood2") > 3: ->fulfilled4|-> followUpFalse2}

->END

=fulfilled4
Elder: Thanks again for all your help Utaka.
Utaka: Im glad i could help.

->END

=followUpFalse
Elder: You dont have enough Stones yet. 
Maybe you could push a big Stone over a Cliff, it might shatter into smaller pieces.

->END

=followUpFalse2
Elder: You dont have enough Wood yet.
Elder: Look for them on the opposite Site from where you found the Stones.

->END

=fulfilled3
Elder: Awesome ! Now you should talk to your Brother.
Elder: He will tell you where to find Firestones.
Utaka: Okay, thanks for your help.
~ Unity_Event("ActivateRiver_Quest")

->END




