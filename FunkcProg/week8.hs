module Week8 where

-- Binárisok

-- Definiáld a `Binary` adattípust, melynek két paraméternélküli adatkonstruktora van: `On` és `Off`. 
-- Kérjük az `Eq` és a `Show` típusosztályok automatikus példányosítását! 
data Binary = On | Off deriving (Eq, Show)

-- Definiálj függvényt, amely az `On` értéket `Off`, az `Off` értéket `On` értékre állítja!
switch :: Binary -> Binary
switch On  = Off
switch Off = On

{- 
switch (switch On) == On
switch (switch (switch Off)) == On
-}

-- Definiáld a `bxor :: [Binary] -> [Binary] -> [Binary]` függvényt, amely visszaad egy listát, amely az `i`-edik pozíción `On` értéket tartalmaz, 
-- ha az `i`-edik pozíción mindkét paraméterben kapott listában egyaránt `On` vagy egyaránt `Off` érték szerepel. 
-- Amennyiben adott pozíción különböző értékeket tartalmaz a két lista, az eredménylistában adjunk vissza `Off` értékeket. 
-- Feltehetjük, hogy a listák egyenlő hosszúak. 

bxor :: [Binary] -> [Binary] -> [Binary]
bxor [] [] = []
bxor (x:xs) (y:ys)
    | x == y    = On : bxor xs ys
    | otherwise = Off : bxor xs ys

{- 
bxor [On] [On]             == [On]
bxor [Off] [Off]           == [On]
bxor [On] [Off]            == [Off]
bxor [Off] [On]            == [Off]
bxor [On, Off] [On, Off]   == [On, On]
bxor [Off, Off] [Off, Off] == [On, On]
bxor [On, On] [On, On]     == [On, On]
bxor [Off, On] [Off, On]   == [On, On]
bxor [On, Off] [Off, Off]  == [Off, On]
bxor [On, Off, On, Off] [Off, On, Off, On] == [Off, Off, Off, Off]
bxor [] [] == []
-}