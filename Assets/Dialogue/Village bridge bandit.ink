
-> main


=== main ===
Hey you... There is a toll for crossing this bridge. #portrait:bandit
You owe me... 10 gold
    * [Thats ridiculous]
        New end of the world policy. Pay the toll or get lost
        ** [Fine I'll pay the toll   -10 gold]
        -> END
        ** [I'd rather die than pay 10 gold]
        Looks like we have a trouble maker here boys
        #battle:bandit
        -> END
    * [I'd rather die than pay 10 gold]
        Looks like we have a trouble maker here boys
        #battle:bandit
        -> END
    * [Is this even your bridge]
        No but we gotta make a livin somehow
        Now pay the toll
            ** [Fine I'll pay the toll   -10 gold]
             -> END
            ** [I'd rather die than pay 10 gold]
            Looks like we have a trouble maker here boys
            #battle:bandit
            -> END