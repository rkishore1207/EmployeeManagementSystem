/* eslint-disable @typescript-eslint/no-explicit-any */

import styled, { css } from "styled-components";
import Constant from "../utils/Constant";

const variation : any = {
    primary: css`
        background-color: var(--color-blue-20);
        color: var(--color-white-50);
        &:hover{
            background-color: var(--color-blue-30);
            color: var(--color-white-40);
        }
    `,

    buttonDisable: css`
        background-color:var(--color-grey-0);
        cursor: not-allowed;
        color:var(--color-white-50);
        &:hover{
            background-color: var(--color-grey-0);
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

    ${
        props => props.variation === Constant.StyledComponentTypes.buttonDisable && variation[props.variation]
    }
`;

Button.defaultProps = {
    variation:Constant.StyledComponentTypes.Primary
}

export default Button;