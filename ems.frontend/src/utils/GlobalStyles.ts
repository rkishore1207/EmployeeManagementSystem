import { createGlobalStyle } from "styled-components";


const GlobalStyle = createGlobalStyle`
:root{
    --color-grey-0: #E8E8E8;
    --color-blue-20: #3FA2F6;
    --color-blue-30: #0F67B1;
    --color-white-50: #FFFFFF;
    --color-black-0: #00334E;
}

*,
*::before,
*::after {
  box-sizing: border-box;
  padding: 0;
  margin: 0;
}

html{
    font-family: Verdana, Geneva, Tahoma, sans-serif;
}

body{
    background-color: #E8E8E8;
}
`

export default GlobalStyle;