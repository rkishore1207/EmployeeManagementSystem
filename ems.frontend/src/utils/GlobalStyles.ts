import { createGlobalStyle } from "styled-components";


const GlobalStyle = createGlobalStyle`
:root{
    --color-grey-0: #E8E8E8;
    --color-blue-20: #3FA2F6;
    --color-blue-30: #0F67B1;
    --color-blue-links: #81aaeb;
    --color-white-40: #f1f6f7;
    --color-white-50: #FFFFFF;
    --color-white-head-side: #FCF8F3;
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

body,html{
    background-color: #E8E8E8;
    margin: 0;
    padding: 0;
    height: 100%;
    box-sizing: border-box;
    /* overflow: hidden; */
}

.container-style{
    margin: 0;
    padding: 0;
}
`

export default GlobalStyle;