let letters = [|
    "e"; "t"; "a"; "o"; "i"; "n"; "s"; "r"; "h"; "l"; "d"; "c"; "u";
    "m"; "f"; "p"; "g"; "w"; "y"; "b"; "v"; "k"; "x"; "j"; "q"; "z"
|]

let digrams = [|
    "th"; "he"; "an"; "in"; "er"; "on"; "re"; "ed"; "nd";
    "ha"; "at"; "en"; "es"; "of"; "nt"; "ea"; "ti"; "to";
    "io"; "le"; "is"; "ou"; "ar"; "as"; "de"; "rt"; "ve"
|]

// Threshold for choosing between single letter and digram
let THRESHOLD = 0.2

let uniformRandObject = System.Random()


let getExpDistRandom lambda = 
    let rnd = uniformRandObject.NextDouble()
    let x = - System.Math.Log(1.0 - (1.0 - System.Math.Exp(-lambda))*rnd) / lambda
    x


let rec composeNickname length lexem = 
    let rnd = getExpDistRandom 1.0
    
    if(length = 2) then
        let digramIdx = rnd * float(digrams.Length - 1) |> int
        lexem + digrams.[digramIdx]
    else if(length = 1) then
        let letterIdx = rnd * float(letters.Length - 1) |> int
        lexem + letters.[letterIdx]
    else
        let chooseLexGroup = uniformRandObject.NextDouble()

        if(chooseLexGroup > THRESHOLD) then
            // choose digrams
            let digramIdx = rnd * float(digrams.Length - 1) |> int
            let rez = (lexem + digrams.[digramIdx]) |> composeNickname (length - 2) 
            rez
        else
            // choose single letters
            let letterIdx = rnd * float(letters.Length - 1) |> int
            let rez = (lexem + letters.[letterIdx]) |> composeNickname (length - 1) 
            rez
        

[<EntryPoint>]
let main argv = 
    
    let nickname = composeNickname 8 ""
    printfn "%s" <| nickname
    0
