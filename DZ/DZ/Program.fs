open System

type SquireRootResult = //SquireRootResult как бы мини-массив переменных
    |NoRoots
    |OneRoot of double
    |TwoRoots of double * double

let Computing(a:double, b:double, c:double):SquireRootResult =
    let D = b*b - 4.0*a*c
    if D < 0.0 then NoRoots
    else if D = 0.0 then
        let x = -b/(2.0 * a)
        OneRoot x
    else
        let sqrtD = Math.Sqrt(D)    //Вычисляем корень от D
        let x1 = (-b + sqrtD) / (2.0 * a)
        let x2 = (-b - sqrtD) / (2.0 * a)
        TwoRoots (x1, x2)

let Print(a:double, b:double, c:double):unit =
    printf "Коэффициенты: a = %A, b = %A, c = %A. " a b c //Перекрёсный вывод
    let root = Computing(a, b, c)
    let text =  //Компановка текста, что будет выведен
        match root with
        | NoRoots -> "D < 0. Корней нет."
        | OneRoot(x) -> "D = 0. Один корень: " + x.ToString()
        | TwoRoots(x1, x2) -> "D > 0. Два корня: " + x1.ToString() + " и " + x2.ToString()
    printfn "%s" text   //Вывод текста, который мы подготовили

let rec Read() =
        printfn "Введите коэффициент:"
        match System.Double.TryParse(System.Console.ReadLine()) with
        | false, _ -> printfn "Введите ещё раз"; Read() //Ошибка, значения не соотвествуют правильным
        | _, _x -> _x

[<EntryPoint>] //Точка старта
let main _ = 
    let mutable a = Read();
    let mutable b = Read();
    let mutable c = Read();
    Print(a, b, c)

    Console.ReadLine()|> ignore //Игнорировать введённые значения ~ Pause

    0 //Возвращение кода выхода