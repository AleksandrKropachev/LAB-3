open System
open System.IO

let romanToInt roman =
    match roman with
    | "I"    -> 1
    | "II"   -> 2
    | "III"  -> 3
    | "IV"   -> 4
    | "V"    -> 5
    | "VI"   -> 6
    | "VII"  -> 7
    | "VIII" -> 8
    | "IX"   -> 9
    | _      -> 0

let chet number =
    number % 2 = 0

let addRoman sm roman =
    sm + romanToInt roman


[<EntryPoint>]
let main argv =

    // ===== ЗАДАНИЕ 1 =====
    printf "Введите числа через пробел: "
    let inputNumbers = Console.ReadLine()

    let numbers =
        inputNumbers.Split(' ')
        |> Seq.choose (fun x ->
            match Int32.TryParse(x) with
            | (true, value) -> Some value
            | _ ->
                printfn "Ошибка: '%s' не является числом и будет пропущено" x
                None)

    let chetSeq =
        numbers
        |> Seq.map chet

    printfn "Список true/false: %A" (Seq.toList chetSeq)
    printfn ""


    // ===== ЗАДАНИЕ 2 =====
    printf "Введите римские числа (I–IX) через пробел: "
    let inputRomans = Console.ReadLine()

    let romanSeq =
        inputRomans.Split(' ')
        |> Seq.choose (fun r ->
            let value = romanToInt r
            if value = 0 then
                printfn "Ошибка: '%s' не является римским числом (I–IX) и будет пропущено" r
                None
            else
                Some r)

    let sum =
        romanSeq
        |> Seq.fold addRoman 0

    printfn "Сумма в десятичной системе: %d" sum
    printfn ""


    // ===== ЗАДАНИЕ 3 =====
    printf "Введите путь к каталогу: "
    let path = Console.ReadLine()

    if Directory.Exists(path) then

        printf "Введите начальный символ имени файла: "
        let symbol = Console.ReadLine().[0]

        let files =
            Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            |> Seq.filter (fun file ->
                let name = Path.GetFileName(file)
                name.StartsWith(symbol.ToString())
            )

        let count = Seq.length files

        if count = 0 then
            printfn "Файлы, начинающиеся с этого символа, не найдены"
        else
            printfn "Количество файлов: %d" count
    else
        printfn "Ошибка: указанная папка не существует"

    0