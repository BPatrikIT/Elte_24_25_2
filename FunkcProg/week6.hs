module Week6 where
    
    tails' :: [a] -> [[a]]
    tails' [] = [[]]
    tails' (x:xs) = (x:xs) : tails' xs

    inits' :: [a] -> [[a]]
    inits' [] = [[]]
    --inits' xs = inits' (init xs) ++ [xs]
    inits' (x:xs) = [] : [ x : list | list <- inits' xs]

    quicksort :: Ord a => [a] -> [a]
    quicksort [] = []
    quicksort (pivot : xs) = quicksort [ x | x <- xs, x < pivot] ++ [pivot] ++ quicksort [ x | x <- xs, x >= pivot]

    mergeSort :: Ord a => [a] -> [a]
    mergeSort [] = []
    mergeSort [x] = [x]
    mergeSort xs = merge (mergeSort (take (length xs `div` 2) xs)) (mergeSort (drop (length xs `div` 2) xs))
        where
            merge [] xs = xs
            merge xs [] = xs
            merge (x : xs) (y : ys)
                | x < y = x : merge xs (y : ys)
                | otherwise = y : merge (x : xs) ys

    deletions :: [a] -> [[a]]
    deletions [] = []
    deletions (x:xs) = xs : [ x : y | y <- deletions xs]