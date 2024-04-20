from model .III3SequentialBlock import III3SequentialBlockImpl
from model .III4ParallelBlock import III4ParallelBlockImpl
from model .III5EnhancedParallelBlock import III5EnhancedParallelBlockImpl
from model .IV3SequentialBlock import IV3SequentialBlockImpl
from model .IV4ParallelBlock import IV4ParallelBlockImpl
from model .IV5EnhancedParallelBlock import IV5EnhancedParallelBlockImpl
from model .NaivLoopUnrollingFour import NaivLoopUnrollingFourImpl
from model .NaivLoopUnrollingTwo import NaivLoopUnrollingTwoImpl
from model .NaivOnArray import NaivOnArrayImpl
#from model .StrassenNaiv import StrassenNaivImpl
#from model .StrassenWinograd import StrassenWinogradImpl
from model .V3SequentialBlock import V3SequentialBlockImpl
from model .V4ParallelBlock import V4ParallelBlockImpl
from model .WinogradOriginal import WinogradOriginalImpl
from model .WinogradScaled import WinogradScaledImpl

def NaivOnArray(matrix_A,matrix_B):
    return NaivOnArrayImpl(matrix_A,matrix_B)

def NaivLoopUnrollingFour(matrix_A,matrix_B):
    return NaivLoopUnrollingFourImpl(matrix_A,matrix_B)

def NaivLoopUnrollingTwo(matrix_A,matrix_B):
    return NaivLoopUnrollingTwoImpl(matrix_A,matrix_B)

def WinogradOriginal(matrix_A,matrix_B):
    return WinogradOriginalImpl(matrix_A,matrix_B)

def WinogradScaled(matrix_A,matrix_B):
    return WinogradScaledImpl(matrix_A,matrix_B)

def III3SequentialBlock(matrix_A,matrix_B):
    return III3SequentialBlockImpl(matrix_A,matrix_B)

def III4ParallelBlock(matrix_A,matrix_B):
    return III4ParallelBlockImpl(matrix_A,matrix_B)

def III5EnhancedParallelBlock(matrix_A,matrix_B):
    return III5EnhancedParallelBlockImpl(matrix_A,matrix_B)

def IV3SequentialBlock(matrix_A,matrix_B):
    return IV3SequentialBlockImpl(matrix_A,matrix_B)

def IV4ParallelBlock(matrix_A,matrix_B):
    return IV4ParallelBlockImpl(matrix_A,matrix_B)

def IV5EnhancedParallelBlock(matrix_A,matrix_B):
    return IV5EnhancedParallelBlockImpl(matrix_A,matrix_B)

def V3SequentialBlock(matrix_A,matrix_B):
    return V3SequentialBlockImpl(matrix_A,matrix_B)

def V4ParallelBlock(matrix_A,matrix_B):
    return V4ParallelBlockImpl(matrix_A,matrix_B)

def StrassenNaiv(matrix_A,matrix_B):
    return StrassenNaivImpl(matrix_A,matrix_B)

def StrassenWinograd(matrix_A,matrix_B):
    return StrassenWinogradImpl(matrix_A,matrix_B)
