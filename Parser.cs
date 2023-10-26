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
    public double Parse(string str)
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
                    while(c != ")"){ 
                        i++;
                        c = str[i].ToString();
                    }
                    i++;
                    c = str[i].ToString();
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
        for(int i = 1; i < size; i += 2){
            double loper;
            string sign = elements[i];
            double roper;
            if(!double.TryParse(elements[i - 1], out loper)){
                return 0;
            }
            if(!double.TryParse(elements[i + 1], out roper)){
                return 0;
            }
            if(double.TryParse(elements[i], out double n)){
                return 0;
            }
            if(i == 1){
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
        return result;
    }
}
