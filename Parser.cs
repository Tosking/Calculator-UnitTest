// See https://aka.ms/new-console-template for more information
public class Parser {

    private string ParseBrackets(string str){
        string result = "";
        for(int i = 0; i < str.Length; i++){
            string c = str[i].ToString();
            if(c == "("){
                result += ParseBrackets(str.Substring(i + 1));
            }
            if(c == ")"){
                return Parse(result).ToString();
            }
            result += c;
        }
        return "0";
    }
    public string Parse(string str)
    {
        List<string> elements = new List<string>();
        string temp = "";
        int size = 0;
        for(int i = 0; i < str.Length; i++){
            string c = str[i].ToString();

            if(int.TryParse(c, out int n) || c == ","){
                temp += c;
            }
            else {
                if(c == "("){
                    elements.Add(ParseBrackets(str.Substring(i+1)));
                    while(c != ")" && (str.Length - 1) > i){ 
                        i++;
                        c = str[i].ToString();
                    }
                    size++;
                }
                if(c != " "){
                    if(temp != ""){
                        elements.Add(temp);
                        size++;
                    }
                    elements.Add(c);
                    size++;
                    temp = "";
                }
            }
        }
        elements.Add(temp);
        size++;
        double result = 0;
        int k = 1;
        if(size == 1){
            return elements[0];
        }
        for(int i = 1; i < size; i += 2){
            while(k < size && k > 0){
                if(elements[k] == "*" || elements[k] == "/"){
                    i = k;
                    k = 1;
                    break;
                }
                k += 2;
                if(k >= size){
                    k = 0;
                    i = 0;
                    break;
                }
            }
            double loper;
            string sign = elements[i];
            double roper;
            if(!double.TryParse(elements[i - 1], out loper)){
                return result.ToString();
            }
            if(!double.TryParse(elements[i + 1], out roper)){
                return result.ToString();
            }
            if(double.TryParse(elements[i], out double n)){
                return result.ToString();
            }
            if(i == 1 && (elements[1] == "+" || elements[1] == "-")){
                result += loper;
            }
            switch(sign){
                case "+":
                    result += roper;
                    break;
                case "-":
                    result -= roper;
                    break;
                case "*":
                    result += loper * roper;
                    
                    break;
                case "/":
                    result += loper / roper;
                    break;
            }
        }
        return result.ToString();
    }
}
