
import styled, { css } from "styled-components";
import Constant from "../utils/Constant";

interface RowProps{
    type? : string;
}

const Row = styled.div<RowProps>`
    width: 100%;
    display: flex;
    align-items: center;

    ${
        props => props.type === Constant.StyledComponentTypes.Vertical && css`
            justify-content: center;
        `
    }
    ${
        props => props.type === Constant.StyledComponentTypes.Horizontal && css`
            flex-direction: column;
            justify-content: center;
        `
    }
`;

Row.defaultProps = {
    type : Constant.StyledComponentTypes.Vertical
}

export default Row;