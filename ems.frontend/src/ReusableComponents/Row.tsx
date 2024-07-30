
import styled, { css } from "styled-components";
import Constant from "../utils/Constant";

interface RowProps{
    type? : string;
}

const Row = styled.div<RowProps>`
    width: 100%;
    display: flex;

    ${
        props => props.type === Constant.StyledComponentTypes.Horizontal && css`
            justify-content: center;
        `
    }
    ${
        props => props.type === Constant.StyledComponentTypes.Vertical && css`
            flex-direction: column;
        `
    }
`;

Row.defaultProps = {
    type : Constant.StyledComponentTypes.Horizontal
}

export default Row;