module Homework10 where
    import Data.Char (isSpace, toUpper)
    import Data.List (isPrefixOf)
    import Data.String (unwords)

    type Line = String
    type File = [Line]

    testFile0 :: File
    testFile0 = ["asd  qwe", "-- Foo", "", "\thello world "]

    countWordsInLine :: Line -> Int
    countWordsInLine = length . words

    countWords :: File -> Int
    countWords = sum . map countWordsInLine

    countChars :: File -> Int
    countChars = sum . map length

    capitalizeWordsInLine :: Line -> Line
    capitalizeWordsInLine = unwords . map capitalize . words
        where
            capitalize (x:xs) = toUpper x : xs
            capitalize [] = []

    isComment :: Line -> Bool
    isComment = ("--" `isPrefixOf`)

    dropComments :: File -> File
    dropComments = filter (not . isComment)

    numberLines :: File -> File
    numberLines = zipWith (\n line -> show n ++ ": " ++ line) [1..]

    dropTrailingWhitespaces :: Line -> Line
    dropTrailingWhitespaces = reverse . dropWhile isSpace . reverse

    replaceTab :: Int -> Char -> [Char]
    replaceTab n '\t' = replicate n ' '
    replaceTab _ c = [c]

    replaceTabs :: Int -> File -> File
    replaceTabs n = map (concatMap (replaceTab n))