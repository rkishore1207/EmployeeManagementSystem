/* eslint-disable @typescript-eslint/no-explicit-any */

import styled, { css } from "styled-components";
import Constant from "../utils/Constant";

const variation : any = {
    primary: css`
        background-color: var(--color-blue-20);
        color: var(--color-white-50);
        &:hover{
            background-color: var(--color-blue-30);
        }
    `
}



interface ButtonProps{
    variation?:string
}

const Button = styled.button<ButtonProps>`
    border: none;
    border-radius: 0.5 rem;
    cursor: pointer;
    padding:0.5 rem;

    ${
        props => props.variation === Constant.StyledComponentTypes.Primary && variation[props.variation]
    }
`;

Button.defaultProps = {
    variation:Constant.StyledComponentTypes.Primary
}

export default Button;