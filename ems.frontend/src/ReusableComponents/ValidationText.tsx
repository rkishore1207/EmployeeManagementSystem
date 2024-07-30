/* eslint-disable @typescript-eslint/no-explicit-any */
import styled from 'styled-components'

const ErrorText = styled.p`
    color: red;
    font-size: smaller;
`;

interface ValidationTextProps{
    children:any
}

const ValidationText = ({children}:ValidationTextProps) => {
    return(
        <ErrorText>{children}</ErrorText>
    )
}

export default ValidationText;
