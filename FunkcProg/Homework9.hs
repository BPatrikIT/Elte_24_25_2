module Homework9 where

type Rank = Int
data Suit = He | Di | Cl | Sp deriving (Show, Eq)
data Card = C Suit Rank deriving (Show, Eq)

pair :: Card -> Card -> Bool
pair c1 c2 = rank c1 == rank c2
  where rank (C _ r) = r

flush :: [Card] -> Bool
flush (x:xs) = all (== suit x) (map suit xs)
  where suit (C s _) = s
flush [] = True

search :: (Suit, Rank) -> [Card] -> Maybe Card
search _ [] = Nothing
search (s, r) (x:xs)
  | suit x == s && rank x == r = Just x
  | otherwise = search (s, r) xs
  where suit (C s _) = s 
        rank (C _ r) = r
        